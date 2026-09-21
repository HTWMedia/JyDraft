using System;
using System.Collections.Generic;
using System.Linq;

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

    public abstract class BaseTrack : IDraftExportable
    {
        public TrackTypeName TrackTypeName { get; protected set; }
        public string Name { get; internal set; }
        public string TrackId { get; internal set; }
        public int RenderIndex { get; internal set; }

        /// <summary>本轨道接受的片段类型；adjust 这类无片段轨道为 null</summary>
        public virtual Type AcceptSegmentType => null;

        /// <summary>
        /// 以基类视角添加一个片段，具体实现负责类型校验与重叠校验。
        /// 有了它，ScriptFile 不再需要反射调用泛型方法。
        /// </summary>
        public abstract void AddSegment(BaseSegment segment);

        public abstract Dictionary<string, object> ExportJson();
    }

    public class Track<T> : BaseTrack where T : BaseSegment
    {
        private readonly List<T> _segments = new List<T>();

        public bool Mute { get; }
        public IReadOnlyList<T> Segments => _segments;

        public Track(TrackTypeName trackType, string name, int renderIndex, bool mute)
        {
            TrackTypeName = trackType;
            Name = name;
            TrackId = Guid.NewGuid().ToString();
            RenderIndex = renderIndex;
            Mute = mute;
        }

        public long EndTime => _segments.Count == 0 ? 0 : _segments[^1].End;

        public override Type AcceptSegmentType => TrackType.Meta[TrackTypeName].SegmentType;

        public override void AddSegment(BaseSegment segment)
        {
            if (segment is not T typed)
                throw new InvalidCastException($"Segment type {segment.GetType()} does not match expected {AcceptSegmentType}");
            AddSegment(typed);
        }

        public Track<T> AddSegment(T segment)
        {
            if (!AcceptSegmentType.IsInstanceOfType(segment))
                throw new InvalidCastException($"Segment type {segment.GetType()} does not match expected {AcceptSegmentType}");

            foreach (var seg in _segments)
            {
                if (seg.Overlaps(segment))
                    throw new Exception($"New segment overlaps with existing segment [start: {segment.TargetTimerange.Start}, end: {segment.TargetTimerange.End}]");
            }

            _segments.Add(segment);
            return this;
        }

        public override Dictionary<string, object> ExportJson()
        {
            var segmentExports = _segments.Select(seg => seg.ExportJson()).ToList();
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

    /// <summary>
    /// 轨道工厂。原先靠 <c>Activator.CreateInstance(typeof(Track&lt;&gt;).MakeGenericType(...))</c>
    /// 反射拼装，编译期无法校验，adjust 轨道还会因为片段类型为 null 直接炸在反射里。
    /// </summary>
    internal static class TrackFactory
    {
        public static BaseTrack Create(TrackTypeName trackType, string name, int renderIndex, bool mute)
        {
            return trackType switch
            {
                TrackTypeName.video => new Track<VideoSegment>(trackType, name, renderIndex, mute),
                TrackTypeName.audio => new Track<AudioSegment>(trackType, name, renderIndex, mute),
                TrackTypeName.effect => new Track<EffectSegment>(trackType, name, renderIndex, mute),
                TrackTypeName.filter => new Track<FilterSegment>(trackType, name, renderIndex, mute),
                TrackTypeName.sticker => new Track<StickerSegment>(trackType, name, renderIndex, mute),
                TrackTypeName.text => new Track<TextSegment>(trackType, name, renderIndex, mute),
                _ => throw new ArgumentException($"轨道类型 '{trackType}' 没有对应的片段类型，无法创建轨道")
            };
        }
    }
}
