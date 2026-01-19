using JyDraft.meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JyDraft.meta.VideoSceneEffectType;
using static JyDraft.TimeUtil;

namespace JyDraft
{
    public class Mask
    {
        public MaskMeta MaskMeta { get; set; }
        public string GlobalId { get; set; }
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double AspectRatio { get; set; }
        public float Rotation { get; set; }
        public bool Invert { get; set; }
        public float Feather { get; set; }
        public float RoundCorner { get; set; }

        public Mask(MaskMeta maskMeta,
                    float cx, float cy, double w, double h,
                    double ratio, float rot, bool inv, float feather, float roundCorner)
        {
            this.MaskMeta = maskMeta;
            this.GlobalId = Guid.NewGuid().ToString();
            this.CenterX = cx;
            this.CenterY = cy;
            this.Width = w;
            this.Height = h;
            this.AspectRatio = ratio;
            this.Rotation = rot;
            this.Invert = inv;
            this.Feather = feather;
            this.RoundCorner = roundCorner;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                ["config"] = new Dictionary<string, object>
                {
                    ["aspectRatio"] = AspectRatio,
                    ["centerX"] = CenterX,
                    ["centerY"] = CenterY,
                    ["feather"] = Feather,
                    ["height"] = Height,
                    ["invert"] = Invert,
                    ["rotation"] = Rotation,
                    ["roundCorner"] = RoundCorner,
                    ["width"] = Width
                },
                ["id"] = GlobalId,
                ["name"] = MaskMeta.Name,
                ["platform"] = "all",
                ["position_info"] = "",
                ["resource_type"] = MaskMeta.ResourceType,
                ["resource_id"] = MaskMeta.ResourceId,
                ["type"] = "mask"
            };
        }
    }

    public class VideoEffect
    {
        public string Name { get; set; }
        public string GlobalId { get; set; }
        public string EffectId { get; set; }
        public string ResourceId { get; set; }
        public string EffectType { get; set; } // "video_effect" or "face_effect"
        public int ApplyTargetType { get; set; } // 0 or 2
        public List<EffectParamInstance> AdjustParams { get; set; }

        // 你需要根据实际情况实现 effectMeta 的类型，可以是父类或接口
        public VideoEffect(
            EffectMeta effectMeta,
            List<float?> parameters = null,
            int applyTargetType = 0
        )
        {
            GlobalId = Guid.NewGuid().ToString();
            AdjustParams = new List<EffectParamInstance>();

            var category = VideoEffectCategoryResolver.GetCategory(effectMeta);
            if (category== VideoEffectCategory.Scene)
            {
                EffectType = "video_effect";
                Name = effectMeta.Name;
                EffectId = effectMeta.EffectId;
                ResourceId = effectMeta.ResourceId;
                AdjustParams = effectMeta.ParseParams(parameters);
            }
            else if (category==VideoEffectCategory.Character)
            {
                EffectType = "face_effect";
                Name = effectMeta.Name;
                EffectId = effectMeta.EffectId;
                ResourceId = effectMeta.ResourceId;
                AdjustParams = effectMeta.ParseParams(parameters);
            }
            else
            {
                throw new ArgumentException("Invalid effect meta type");
            }
            ApplyTargetType = applyTargetType;
            
        }

        public Dictionary<string, object> ExportJson()
        {
            var adjustParamsJson = new List<object>();
            foreach (var param in AdjustParams)
            {
                adjustParamsJson.Add(param.ExportJson());
            }

            return new Dictionary<string, object>
            {
                ["adjust_params"] = adjustParamsJson,
                ["apply_target_type"] = ApplyTargetType,
                ["apply_time_range"] = null,
                ["category_id"] = "",
                ["category_name"] = "",
                ["common_keyframes"] = new List<object>(),
                ["disable_effect_faces"] = new List<object>(),
                ["effect_id"] = EffectId,
                ["formula_id"] = "",
                ["id"] = GlobalId,
                ["name"] = Name,
                ["platform"] = "all",
                ["render_index"] = 11000,
                ["resource_id"] = ResourceId,
                ["source_platform"] = 0,
                ["time_range"] = null,
                ["track_render_index"] = 0,
                ["type"] = EffectType,
                ["value"] = 1.0,
                ["version"] = ""
            };
        }
    }

    public class Filter
    {
        /// <summary>滤镜全局 ID</summary>
        public string GlobalId { get; private set; }

        /// <summary>滤镜的元数据</summary>
        public EffectMeta EffectMeta { get; set; }

        /// <summary>滤镜强度</summary>
        public float Intensity { get; set; }

        /// <summary>应用目标类型：0 - 片段，2 - 全局</summary>
        public int ApplyTargetType { get; set; }

        public Filter(EffectMeta meta, float intensity, int applyTargetType = 0)
        {
            GlobalId = Guid.NewGuid().ToString();
            EffectMeta = meta;
            Intensity = intensity;
            ApplyTargetType = applyTargetType;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                ["adjust_params"] = new List<object>(),
                ["algorithm_artifact_path"] = "",
                ["apply_target_type"] = ApplyTargetType,
                ["bloom_params"] = null,
                ["category_id"] = "",
                ["category_name"] = "",
                ["color_match_info"] = new Dictionary<string, object>
                {
                    ["source_feature_path"] = "",
                    ["target_feature_path"] = "",
                    ["target_image_path"] = ""
                },
                ["effect_id"] = EffectMeta.EffectId,
                ["enable_skin_tone_correction"] = false,
                ["exclusion_group"] = new List<object>(),
                ["face_adjust_params"] = new List<object>(),
                ["formula_id"] = "",
                ["id"] = GlobalId,
                ["intensity_key"] = "",
                ["multi_language_current"] = "",
                ["name"] = EffectMeta.Name,
                ["panel_id"] = "",
                ["platform"] = "all",
                ["resource_id"] = EffectMeta.ResourceId,
                ["source_platform"] = 1,
                ["sub_type"] = "none",
                ["time_range"] = null,
                ["type"] = "filter",
                ["value"] = Intensity,
                ["version"] = ""
            };
        }
    }

    public class Transition
    {
        /// <summary>转场名称</summary>
        public string Name { get; set; }

        /// <summary>转场全局id，由程序自动生成</summary>
        public string GlobalId { get; set; }

        /// <summary>转场效果id，由剪映本身提供</summary>
        public string EffectId { get; set; }

        /// <summary>资源id，由剪映本身提供</summary>
        public string ResourceId { get; set; }

        /// <summary>转场持续时间，单位为微秒</summary>
        public int Duration { get; set; }

        /// <summary>是否与上一个片段重叠</summary>
        public bool IsOverlap { get; set; }

        public Transition(TransitionMeta transitionMeta, int? duration = null)
        {
            Name = transitionMeta.Name;
            GlobalId = Guid.NewGuid().ToString(); // 相当于 Python 的 uuid.uuid4().hex
            EffectId = transitionMeta.EffectId;
            ResourceId = transitionMeta.ResourceId;
            Duration = duration ?? transitionMeta.DefaultDuration;
            IsOverlap = transitionMeta.IsOverlap;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "category_id", "" },
                { "category_name", "" },
                { "duration", Duration },
                { "effect_id", EffectId },
                { "id", GlobalId },
                { "is_overlap", IsOverlap },
                { "name", Name },
                { "platform", "all" },
                { "resource_id", ResourceId },
                { "type", "transition" }
                // 不导出 path 和 request_id
            };
        }
    }

    public class BackgroundFilling
    {
        /// <summary>
        /// 背景填充全局ID，由程序自动生成
        /// </summary>
        public string GlobalId { get; private set; }

        /// <summary>
        /// 背景填充类型："canvas_blur" 或 "canvas_color"
        /// </summary>
        public string FillType { get; private set; }

        /// <summary>
        /// 模糊程度，范围 0-1
        /// </summary>
        public double Blur { get; private set; }

        /// <summary>
        /// 背景颜色，格式为 "#RRGGBBAA"
        /// </summary>
        public string Color { get; private set; }

        public BackgroundFilling(string fillType, double blur, string color)
        {
            if (fillType != "canvas_blur" && fillType != "canvas_color")
                throw new ArgumentException("fillType must be either 'canvas_blur' or 'canvas_color'");

            if (blur < 0 || blur > 1)
                throw new ArgumentOutOfRangeException(nameof(blur), "blur must be between 0 and 1");

            if (string.IsNullOrEmpty(color) || !color.StartsWith("#") || color.Length != 9)
                throw new ArgumentException("color must be in the format '#RRGGBBAA'");

            GlobalId = Guid.NewGuid().ToString();
            FillType = fillType;
            Blur = blur;
            Color = color;
        }

        /// <summary>
        /// 导出为 JSON 对象（使用 Dictionary 表示）
        /// </summary>
        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "id", GlobalId },
                { "type", FillType },
                { "blur", Blur },
                { "color", Color },
                { "source_platform", 0 }
            };
        }
    }

    public class VideoSegment : VisualSegment
    {
        public VideoMaterial MaterialInstance { get; set; }
        public (int Width, int Height) MaterialSize { get; set; }
        public List<VideoEffect> Effects { get; set; } = new List<VideoEffect>();
        public List<Filter> Filters { get; set; } = new List<Filter>();
        public Mask Mask { get; set; }
        public Transition Transition { get; set; }
        public BackgroundFilling BackgroundFilling { get; set; }

        public VideoSegment(
            VideoMaterial material,
            Timerange targetTimerange,
            Timerange sourceTimerange = null,
            double? speed = null,
            double volume = 1.0,
            ClipSettings clipSettings = null)
            : base(material.MaterialId, sourceTimerange, targetTimerange, speed ?? 1.0, volume, clipSettings)
        {
            if (sourceTimerange != null && speed.HasValue)
            {
                targetTimerange = new Timerange(targetTimerange.Start, (int)(sourceTimerange.Duration / speed.Value));
            }
            else if (sourceTimerange != null && !speed.HasValue)
            {
                speed = sourceTimerange.Duration / targetTimerange.Duration;
            }
            else
            {
                speed ??= 1.0;
                sourceTimerange = new Timerange(0, (int)(targetTimerange.Duration * speed.Value));
            }

            if (sourceTimerange.End > material.Duration)
                throw new ArgumentOutOfRangeException("sourceTimerange 超出了素材时长");

            // 初始化父类
            base.SourceTimerange = sourceTimerange;
            base.TargetTimerange = targetTimerange;
            base.Speed.Value = speed.Value;

            this.MaterialInstance = material;
            this.MaterialSize = (material.Width, material.Height);
        }

        public VideoSegment AddAnimation(
    AnimationMeta animationMeta, // 可以是 IntroType, OutroType, 或 GroupAnimationType
    object duration = null // 可以是 int 或 string 或 null
)
        {
            long? resolvedDuration = null;
            long start = 0;

            // 假设有类似 tim() 的解析方法
            if (duration != null)
            {
                if (duration is string strDuration)
                {
                    resolvedDuration = Tim(strDuration);
                }
                else if (duration is int intDuration)
                {
                    resolvedDuration = intDuration;
                }
                else
                {
                    throw new ArgumentException("duration must be int or string");
                }
            }

            var category = AnimationCategoryResolver.GetCategory(animationMeta);
            var categoryName = "in";
            switch (category)
            {
                case AnimationCategory.Intro:
                    start = 0;
                    resolvedDuration ??= animationMeta.Duration;
                    categoryName = "in";
                    break;

                case AnimationCategory.Outro:
                    resolvedDuration ??= animationMeta.Duration;
                    start = this.TargetTimerange.Duration - resolvedDuration.Value;
                    categoryName = "out";
                    break;

                case AnimationCategory.Group:
                    start = 0;
                    resolvedDuration ??= this.TargetTimerange.Duration;
                    categoryName = "group";
                    break;

                default:
                    throw new InvalidOperationException("无法识别动画类型。");
            }

            if (this.AnimationsInstance == null)
            {
                this.AnimationsInstance = new SegmentAnimations();
                this.ExtraMaterialRefs.Add(this.AnimationsInstance.AnimationId);
            }

            this.AnimationsInstance.AddAnimation(
                new VideoAnimation(animationMeta,categoryName, start, resolvedDuration.Value)
            );

            return this;
        }

        public VideoSegment AddEffect(EffectMeta effectType, List<float?> parameters = null)
        {
            var effect = new VideoEffect(effectType, parameters);
            Effects.Add(effect);
            ExtraMaterialRefs.Add(effect.GlobalId);
            return this;
        }

        public VideoSegment AddFilter(EffectMeta meta, float intensity = 100.0f)
        {
            var filter = new Filter(meta, intensity / 100.0f);
            Filters.Add(filter);
            ExtraMaterialRefs.Add(filter.GlobalId);
            return this;
        }

        public VideoSegment AddMask(MaskMeta type, float centerX = 0.0f, float centerY = 0.0f, float size = 0.5f,
                                     float rotation = 0.0f, float feather = 0.0f, bool invert = false,
                                     double? rectWidth = null, float? roundCorner = null)
        {
            if (Mask != null)
                throw new InvalidOperationException("当前片段已有蒙版");

            if ((rectWidth != null || roundCorner != null) && type != MaskType.矩形)
                throw new ArgumentException("仅矩形蒙版可设置 rectWidth 或 roundCorner");

            rectWidth ??= size;
            roundCorner ??= 0f;

            var widthRatio = MaterialSize.Height * type.DefaultAspectRatio / MaterialSize.Width;
            var mask = new Mask(type, centerX, centerY,
                                rectWidth.Value * widthRatio, size,
                                type.DefaultAspectRatio, rotation, invert,
                                feather / 100, roundCorner.Value / 100);
            this.Mask = mask;
            ExtraMaterialRefs.Add(mask.GlobalId);
            return this;
        }

        public VideoSegment AddTransition(TransitionMeta type, object duration = null)
        {
            if (Transition != null)
                throw new InvalidOperationException("当前片段已有转场");

            int dur = duration is string s ? Convert.ToInt32(TimeUtil.SrtTstamp(s)) : Convert.ToInt32(duration);
            this.Transition = new Transition(type, dur);
            ExtraMaterialRefs.Add(Transition.GlobalId);
            return this;
        }

        public VideoSegment AddBackgroundFilling(string fillType, double blur = 0.0625, string color = "#00000000")
        {
            if (BackgroundFilling != null)
                throw new InvalidOperationException("已有背景填充");

            if (fillType == "blur")
                BackgroundFilling = new BackgroundFilling("canvas_blur", blur, color);
            else if (fillType == "color")
                BackgroundFilling = new BackgroundFilling("canvas_color", blur, color);
            else
                throw new ArgumentException($"无效的背景填充类型 {fillType}");

            ExtraMaterialRefs.Add(BackgroundFilling.GlobalId);
            return this;
        }

        public override Dictionary<string, object> ExportJson()
        {
            var json = base.ExportJson();
            json["hdr_settings"] = new Dictionary<string, object>
            {
                { "intensity", 1.0 },
                { "mode", 1 },
                { "nits", 1000 }
            };
            return json;
        }
    }

    /// <summary>
    /// 安放在轨道上的一个贴纸片段
    /// </summary>
    public class StickerSegment : VisualSegment
    {
        /// <summary>
        /// 贴纸资源id
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// 根据贴纸resource_id构建一个贴纸片段, 并指定其时间信息及图像调节设置
        /// 片段创建完成后, 可通过ScriptFile.AddSegment方法将其添加到轨道中
        /// </summary>
        /// <param name="resourceId">贴纸resource_id, 可通过ScriptFile.InspectMaterial从模板中获取</param>
        /// <param name="targetTimerange">片段在轨道上的目标时间范围</param>
        /// <param name="clipSettings">图像调节设置, 默认不作任何变换</param>
        public StickerSegment(string resourceId, Timerange targetTimerange, ClipSettings clipSettings = null)
            : base(Guid.NewGuid().ToString(), null, targetTimerange, 1.0, 1.0, clipSettings)
        {
            this.ResourceId = resourceId;
        }

        /// <summary>
        /// 创建极简的贴纸素材对象, 以此不再单独定义贴纸素材类
        /// </summary>
        /// <returns>字典形式的贴纸素材对象</returns>
        public Dictionary<string, object> ExportMaterial()
        {
            return new Dictionary<string, object>
            {
                { "id", this.MaterialId },
                { "resource_id", this.ResourceId },
                { "sticker_id", this.ResourceId },
                { "source_platform", 1 },
                { "type", "sticker" }
            };
        }
    }
}
