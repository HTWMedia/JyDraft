using System;
using System.Collections.Generic;
using System.Linq;
using static JyDraft.TimeUtil;

namespace JyDraft
{
    /// <summary>
    /// 所有片段的基类：只负责「身份 + 时间区间 + 关键帧 + 附加素材引用」。
    /// 状态一律由本类保护，子类通过 <see cref="AddExtraMaterialRef"/> /
    /// <see cref="AddKeyframeInternal"/> 修改，避免外部把片段改到不一致的状态。
    /// </summary>
    public class BaseSegment : IDraftExportable
    {
        public string SegmentId { get; }

        /// <summary>素材 id；模板模式下替换素材需要改写，故只放开 internal set</summary>
        public string MaterialId { get; internal set; }

        public Timerange TargetTimerange { get; protected set; }

        private readonly List<KeyframeList> _commonKeyframes = new List<KeyframeList>();
        private readonly List<string> _extraMaterialRefs = new List<string>();

        public IReadOnlyList<KeyframeList> CommonKeyframes => _commonKeyframes;

        /// <summary>附加素材（动画、转场、滤镜…）的全局 id 列表</summary>
        public IReadOnlyList<string> ExtraMaterialRefs => _extraMaterialRefs;

        public BaseSegment(string materialId, Timerange targetTimerange)
        {
            SegmentId = Guid.NewGuid().ToString();
            MaterialId = materialId;
            TargetTimerange = targetTimerange;
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

        public bool Overlaps(BaseSegment other) => TargetTimerange.Overlaps(other.TargetTimerange);

        /// <summary>登记一个附加素材，并把它挂到 extra_material_refs 上</summary>
        protected void AddExtraMaterialRef(string globalId)
        {
            if (!string.IsNullOrEmpty(globalId))
                _extraMaterialRefs.Add(globalId);
        }

        /// <summary>向指定属性的关键帧列表追加一帧（列表不存在则创建）</summary>
        protected void AddKeyframeInternal(KeyframeProperty property, int timeOffset, float value)
        {
            var kfList = _commonKeyframes.FirstOrDefault(k => k.Property == property);
            if (kfList == null)
            {
                kfList = new KeyframeList(property);
                _commonKeyframes.Add(kfList);
            }
            kfList.AddKeyframe(timeOffset, value);
        }

        /// <summary>
        /// 把本片段依赖的所有素材登记进草稿的素材池。默认什么都不做，
        /// 需要登记素材的片段（视频 / 音频 / 文本 / 贴纸）各自重写。
        /// 原先这段逻辑是 ScriptFile 里一个按类型 switch 的大方法。
        /// </summary>
        internal virtual void CollectMaterials(ScriptMaterial materials) { }

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
                { "common_keyframes", _commonKeyframes.ConvertAll(kf => kf.ExportJson()) },
                { "keyframe_refs", new List<object>() }
            };
        }
    }

    /// <summary>固定速度对象（原名 Speed，与 MediaSegment.Speed 属性同名，读代码时极易混淆）</summary>
    public class SpeedMaterial : IDraftExportable
    {
        public string GlobalId { get; }
        public double Value { get; }

        public SpeedMaterial(double speed)
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
    public class ClipSettings : IDraftExportable
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
        public Timerange SourceTimerange { get; protected set; }

        /// <summary>片段速度。构造时推导确定、之后不可变（原实现靠子类回填 Speed.Value）</summary>
        public SpeedMaterial Speed { get; }

        public double Volume { get; protected set; }

        public MediaSegment(string materialId, Timerange sourceTimerange, Timerange targetTimerange, double speed, double volume)
            : base(materialId, targetTimerange)
        {
            SourceTimerange = sourceTimerange;
            Speed = new SpeedMaterial(speed);
            Volume = volume;
            AddExtraMaterialRef(Speed.GlobalId);
        }

        public override Dictionary<string, object> ExportJson()
        {
            var ret = base.ExportJson();
            ret["source_timerange"] = SourceTimerange != null ? SourceTimerange.ExportJson() : null;
            ret["speed"] = Speed.Value;
            ret["volume"] = Volume;
            ret["extra_material_refs"] = ExtraMaterialRefs.ToList();
            return ret;
        }
    }

    // 视觉片段基类
    public class VisualSegment : MediaSegment
    {
        public ClipSettings ClipSettings { get; internal set; }
        public bool UniformScale { get; private set; }

        /// <summary>附加在本片段上的动画组；由 <see cref="EnsureAnimations"/> 惰性创建</summary>
        public SegmentAnimations AnimationsInstance { get; private set; }

        public VisualSegment(string materialId, Timerange sourceTimerange, Timerange targetTimerange,
                             double speed, double volume, ClipSettings clipSettings = null)
            : base(materialId, sourceTimerange, targetTimerange, speed, volume)
        {
            ClipSettings = clipSettings ?? new ClipSettings();
            UniformScale = true;
            AnimationsInstance = null;
        }

        /// <summary>确保动画组已创建并把 id 挂到 extra_material_refs（原先每个子类各写一遍）</summary>
        protected SegmentAnimations EnsureAnimations()
        {
            if (AnimationsInstance == null)
            {
                AnimationsInstance = new SegmentAnimations();
                AddExtraMaterialRef(AnimationsInstance.AnimationId);
            }
            return AnimationsInstance;
        }

        /// <summary>
        /// 从模板片段沿用动画组（CreateFromTemplate 用）：复用同一实例并换一个新 id，
        /// 与重构前行为保持一致。
        /// </summary>
        internal void AdoptAnimationsFrom(VisualSegment template)
        {
            AnimationsInstance = template.AnimationsInstance;
            AnimationsInstance.AnimationId = Guid.NewGuid().ToString();
            AddExtraMaterialRef(AnimationsInstance.AnimationId);
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

            int time = timeOffset is string str ? TimeUtil.Tim(str) : Convert.ToInt32(timeOffset);
            AddKeyframeInternal(property, time, value);
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
