using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft
{
    public class TrackMeta
    {
        public Type SegmentType { get; }
        public int RenderIndex { get; }
        public bool AllowModify { get; }

        public TrackMeta(Type segmentType, int renderIndex, bool allowModify)
        {
            SegmentType = segmentType;
            RenderIndex = renderIndex;
            AllowModify = allowModify;
        }
    }

    public enum TrackTypeName
    {
        video,
        audio,
        effect,
        filter,
        sticker,
        text,
        adjust
    }

    public class TrackType
    {
        public static readonly Dictionary<TrackTypeName, TrackMeta> Meta = new()
        {
            { TrackTypeName.video, new TrackMeta(typeof(VideoSegment), 0, true) },
            { TrackTypeName.audio, new TrackMeta(typeof(AudioSegment), 0, true) },
            { TrackTypeName.effect, new TrackMeta(typeof(EffectSegment), 10000, false) },
            { TrackTypeName.filter, new TrackMeta(typeof(FilterSegment), 11000, false) },
            { TrackTypeName.sticker, new TrackMeta(typeof(StickerSegment), 14000, false) },
            { TrackTypeName.text, new TrackMeta(typeof(TextSegment), 15000, true) },
            { TrackTypeName.adjust, new TrackMeta(null, 0, false) }
        };

        public static TrackTypeName FromName(string name)
        {
            if (Enum.TryParse(name, out TrackTypeName result))
                return result;
            throw new ArgumentException($"Invalid track type: {name}");
        }
    }

    public abstract class BaseTrack
    {
        public TrackTypeName TrackTypeName { get; protected set; }
        public string Name { get; set; }
        public string TrackId { get; protected set; }
        public int RenderIndex { get; set; }

        public virtual Type AcceptSegmentType { get; }
        public abstract Dictionary<string, object> ExportJson();
    }

    public class Track<T> : BaseTrack where T : BaseSegment
    {
        public bool Mute { get; set; }
        public List<T> Segments { get; set; }

        public Track(TrackTypeName trackType, string name, int renderIndex, bool mute)
        {
            TrackTypeName = trackType;
            Name = name;
            TrackId = Guid.NewGuid().ToString();
            RenderIndex = renderIndex;
            Mute = mute;
            Segments = new List<T>();
        }

        public long EndTime => Segments.Count == 0 ? 0 : Segments[^1].TargetTimerange.End;

        public override Type AcceptSegmentType => TrackType.Meta[TrackTypeName].SegmentType;

        public Track<T> AddSegment(T segment)
        {
            if (!AcceptSegmentType.IsInstanceOfType(segment))
                throw new InvalidCastException($"Segment type {segment.GetType()} does not match expected {AcceptSegmentType}");

            foreach (var seg in Segments)
            {
                if (seg.Overlaps(segment))
                    throw new Exception($"New segment overlaps with existing segment [start: {segment.TargetTimerange.Start}, end: {segment.TargetTimerange.End}]");
            }

            Segments.Add(segment);
            return this;
        }

        public override Dictionary<string, object> ExportJson()
        {
            var segmentExports = Segments.Select(seg => seg.ExportJson()).ToList();

            foreach (var seg in segmentExports)
                seg["render_index"] = RenderIndex;

            return new Dictionary<string, object>
        {
            { "attribute", Mute ? 1 : 0 },
            { "flag", 0 },
            { "id", TrackId },
            { "is_default_name", string.IsNullOrEmpty(Name) },
            { "name", Name },
            { "segments", segmentExports },
            { "type", TrackTypeName.ToString() }
        };
        }
    }
}
