using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JyDraft.TimeUtil;

namespace JyDraft
{
    public class BaseSegment
    {
        public string SegmentId { get; set; }
        public string MaterialId { get; set; }
        public Timerange TargetTimerange { get; set; }
        public List<KeyframeList> CommonKeyframes { get; set; }

        public BaseSegment(string materialId, Timerange targetTimerange)
        {
            SegmentId = Guid.NewGuid().ToString();
            MaterialId = materialId;
            TargetTimerange = targetTimerange;
            CommonKeyframes = new List<KeyframeList>();
        }

        public long Start
        {
            get => TargetTimerange.Start;
            set => TargetTimerange.Start = value;
        }

        public long Duration
        {
            get => TargetTimerange.Duration;
            set => TargetTimerange.Duration = value;
        }

        public long End => TargetTimerange.End;

        public bool Overlaps(BaseSegment other)
        {
            return TargetTimerange.Overlaps(other.TargetTimerange);
        }

        public virtual Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "enable_adjust", true },
                { "enable_color_correct_adjust", false },
                { "enable_color_curves", true },
                { "enable_color_match_adjust", false },
                { "enable_color_wheels", true },
                { "enable_lut", true },
                { "enable_smart_color_adjust", false },
                { "last_nonzero_volume", 1.0 },
                { "speed", 1 },
                { "reverse", false },
                { "render_index", 0 },
                { "is_placeholder", false },
                { "template_id", "" },
                { "template_scene", "default" },
                { "track_attribute", 0 },
                { "track_render_index", 0 },
                { "visible", true },
                { "id", SegmentId },
                { "material_id", MaterialId },
                { "target_timerange", TargetTimerange.ExportJson() },
                { "common_keyframes", CommonKeyframes.ConvertAll(kf => kf.ExportJson()) },
                { "keyframe_refs", new List<object>() }
            };
        }
    }

    // 固定速度对象
    public class Speed
    {
        public string GlobalId { get; set; }
        public double Value { get; set; }

        public Speed(double speed)
        {
            GlobalId = Guid.NewGuid().ToString();
            Value = speed;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "curve_speed", null },
                { "id", GlobalId },
                { "mode", 0 },
                { "speed", Value },
                { "type", "speed" }
            };
        }
    }

    // 图像调节设置
    public class ClipSettings
    {
        public float Alpha { get; set; }
        public bool FlipHorizontal { get; set; }
        public bool FlipVertical { get; set; }
        public float Rotation { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float TransformX { get; set; }
        public float TransformY { get; set; }

        public ClipSettings(float alpha = 1.0f, bool flipHorizontal = false, bool flipVertical = false,
                            float rotation = 0.0f, float scaleX = 1.0f, float scaleY = 1.0f,
                            float transformX = 0.0f, float transformY = 0.0f)
        {
            Alpha = alpha;
            FlipHorizontal = flipHorizontal;
            FlipVertical = flipVertical;
            Rotation = rotation;
            ScaleX = scaleX;
            ScaleY = scaleY;
            TransformX = transformX;
            TransformY = transformY;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "alpha", Alpha },
                { "flip", new Dictionary<string, object>
                    { { "horizontal", FlipHorizontal }, { "vertical", FlipVertical } }
                },
                { "rotation", Rotation },
                { "scale", new Dictionary<string, object> { { "x", ScaleX }, { "y", ScaleY } } },
                { "transform", new Dictionary<string, object> { { "x", TransformX }, { "y", TransformY } } }
            };
        }
    }

    // 媒体片段基类
    public class MediaSegment : BaseSegment
    {
        public Timerange SourceTimerange { get; set; }
        public Speed Speed { get; set; }
        public double Volume { get; set; }
        public List<string> ExtraMaterialRefs { get; set; }

        public MediaSegment(string materialId, Timerange sourceTimerange, Timerange targetTimerange, double speed, double volume)
            : base(materialId, targetTimerange)
        {
            SourceTimerange = sourceTimerange;
            Speed = new Speed(speed);
            Volume = volume;
            ExtraMaterialRefs = new List<string> { Speed.GlobalId };
        }

        public override Dictionary<string, object> ExportJson()
        {
            var ret = base.ExportJson();
            ret["source_timerange"] = SourceTimerange != null ? SourceTimerange.ExportJson() : null;
            ret["speed"] = Speed.Value;
            ret["volume"] = Volume;
            ret["extra_material_refs"] = ExtraMaterialRefs;
            return ret;
        }
    }

    // 视觉片段基类
    public class VisualSegment : MediaSegment
    {
        public ClipSettings ClipSettings { get; set; }
        public bool UniformScale { get; set; }
        public SegmentAnimations AnimationsInstance { get; set; }

        public VisualSegment(string materialId, Timerange sourceTimerange, Timerange targetTimerange,
                             double speed, double volume, ClipSettings clipSettings = null)
            : base(materialId, sourceTimerange, targetTimerange, speed, volume)
        {
            ClipSettings = clipSettings ?? new ClipSettings();
            UniformScale = true;
            AnimationsInstance = null;
        }

        public VisualSegment AddKeyframe(KeyframeProperty property, object timeOffset, float value)
        {
            if ((property == KeyframeProperty.ScaleX || property == KeyframeProperty.ScaleY) && UniformScale)
            {
                UniformScale = false;
            }
            else if (property == KeyframeProperty.UniformScale)
            {
                if (!UniformScale)
                    throw new Exception("已设置 scale_x 或 scale_y 时, 不能再设置 uniform_scale");
                property = KeyframeProperty.ScaleX;
            }

            int time;
            if (timeOffset is string)
                time = TimeUtil.Tim(timeOffset); // 需实现
            else
                time = Convert.ToInt32(timeOffset);

            foreach (var kfList in CommonKeyframes)
            {
                if (kfList.Property == property)
                {
                    kfList.AddKeyframe(time, value);
                    return this;
                }
            }
            var newKfList = new KeyframeList(property);
            newKfList.AddKeyframe(time, value);
            CommonKeyframes.Add(newKfList);
            return this;
        }

        public override Dictionary<string, object> ExportJson()
        {
            var dict = base.ExportJson();
            dict["clip"] = ClipSettings.ExportJson();
            dict["uniform_scale"] = new Dictionary<string, object> { { "on", UniformScale }, { "value", 1.0f } };
            return dict;
        }
    }
}
