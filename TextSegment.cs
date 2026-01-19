using JyDraft.meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static JyDraft.TimeUtil;

namespace JyDraft
{
    // 字体样式类
    public class TextStyle
    {
        public float Size { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public bool Underline { get; set; }

        // 字体颜色，RGB三元组，取值范围为[0, 1]
        public float[] Color { get; set; }
        public float Alpha { get; set; }

        // 对齐方式
        public int Align { get; set; }
        public bool Vertical { get; set; }

        public int LetterSpacing { get; set; }
        public int LineSpacing { get; set; }

        public TextStyle(float size = 8.0f, bool bold = false, bool italic = false, bool underline = false,
                         float[] color = null, float alpha = 1.0f,
                         int align = 0, bool vertical = false,
                         int letterSpacing = 0, int lineSpacing = 0)
        {
            Size = size;
            Bold = bold;
            Italic = italic;
            Underline = underline;
            Color = color ?? new float[] { 1.0f, 1.0f, 1.0f };
            Alpha = alpha;
            Align = align;
            Vertical = vertical;
            LetterSpacing = letterSpacing;
            LineSpacing = lineSpacing;
        }
    }

    // 文本描边参数
    public class TextBorder
    {
        public float Alpha { get; set; }
        public float[] Color { get; set; }
        public float Width { get; set; }

        public TextBorder(float alpha = 1.0f, float[] color = null, float width = 40.0f)
        {
            Alpha = alpha;
            Color = color ?? new float[] { 0.0f, 0.0f, 0.0f };
            Width = width / 100.0f * 0.2f; // 映射规则
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object> {
            { "content", new Dictionary<string, object> {
                { "solid", new Dictionary<string, object> {
                    { "alpha", Alpha },
                    { "color", Color }
                }}
            }},
            { "width", Width }
        };
        }
    }

    // 文本背景参数
    public class TextBackground
    {
        public int Style { get; set; }
        public float Alpha { get; set; }
        public string Color { get; set; }
        public float RoundRadius { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float HorizontalOffset { get; set; }
        public float VerticalOffset { get; set; }

        public TextBackground(string color, int style = 1, float alpha = 1.0f, float roundRadius = 0.0f,
                             float height = 0.14f, float width = 0.14f,
                             float horizontalOffset = 0.5f, float verticalOffset = 0.5f)
        {
            Style = (style == 1) ? 0 : 2;
            Alpha = alpha;
            Color = color;
            RoundRadius = roundRadius;
            Height = height;
            Width = width;
            HorizontalOffset = horizontalOffset * 2 - 1;
            VerticalOffset = verticalOffset * 2 - 1;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object> {
            { "background_style", Style },
            { "background_color", Color },
            { "background_alpha", Alpha },
            { "background_round_radius", RoundRadius },
            { "background_height", Height },
            { "background_width", Width },
            { "background_horizontal_offset", HorizontalOffset },
            { "background_vertical_offset", VerticalOffset }
        };
        }
    }

    // 文本气泡
    public class TextBubble
    {
        public string GlobalId { get; private set; }
        public string EffectId { get; set; }
        public string ResourceId { get; set; }

        public TextBubble(string effectId, string resourceId)
        {
            GlobalId = Guid.NewGuid().ToString();
            EffectId = effectId;
            ResourceId = resourceId;
        }

        public virtual Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object> {
            { "apply_target_type", 0 },
            { "effect_id", EffectId },
            { "id", GlobalId },
            { "resource_id", ResourceId },
            { "type", "text_shape" },
            { "value", 1.0 }
        };
        }
    }

    // 文本花字
    public class TextEffect : TextBubble
    {
        public TextEffect(string effectId, string resourceId) : base(effectId, resourceId) { }

        public override Dictionary<string, object> ExportJson()
        {
            var ret = base.ExportJson();
            ret["type"] = "text_effect";
            ret["source_platform"] = 1;
            return ret;
        }
    }

   
    // 文本片段类
    public class TextSegment : VisualSegment
    {
        public string Text { get; set; }
        public EffectMeta Font { get; set; }
        public TextStyle Style { get; set; }

        public TextBorder Border { get; set; }
        public TextBackground Background { get; set; }

        public TextBubble Bubble { get; set; }
        public TextEffect Effect { get; set; }

        public TextSegment(string text, Timerange timerange,
            EffectMeta font = null,
            TextStyle style = null,
            ClipSettings clipSettings = null,
            TextBorder border = null,
            TextBackground background = null)
            : base(Guid.NewGuid().ToString(), null, timerange, 1.0, 1.0, clipSettings)
        {
            Text = text;
            Font = font;
            Style = style ?? new TextStyle();
            Border = border;
            Background = background;

            Bubble = null;
            Effect = null;
        }

        public static TextSegment CreateFromTemplate(string text, Timerange timerange, TextSegment template)
        {
            var newSegment = new TextSegment(
                text,
                timerange,
                style: template.Style,
                clipSettings: template.ClipSettings,
                border: template.Border,
                background: template.Background
            )
            {
                Font = template.Font
            };

            if (template.AnimationsInstance != null)
            {
                newSegment.AnimationsInstance = template.AnimationsInstance;
                newSegment.AnimationsInstance.AnimationId = Guid.NewGuid().ToString();
                newSegment.ExtraMaterialRefs.Add(newSegment.AnimationsInstance.AnimationId);
            }

            if (template.Bubble != null)
            {
                newSegment.AddBubble(template.Bubble.EffectId, template.Bubble.ResourceId);
            }

            if (template.Effect != null)
            {
                newSegment.AddEffect(template.Effect.EffectId);
            }

            return newSegment;
        }

        public TextSegment AddAnimation(AnimationMeta meta, string animationType, object duration = null)
        {
            long dur = TimeUtil.Tim(duration ?? 500000L);
            dur = Math.Min(dur, TargetTimerange.Duration);

            long start = 0;

            if (animationType=="in")
            {
                start = 0;
            }
            else if (animationType=="out")
            {
                start = TargetTimerange.Duration - dur;
            }
            else if (animationType=="loop")
            {
                var introRange = AnimationsInstance?.GetAnimationTrange("in");
                var outroRange = AnimationsInstance?.GetAnimationTrange("out");

                start = introRange?.Start ?? 0;
                dur = TargetTimerange.Duration - start - (outroRange?.Duration ?? 0);
            }
            else
            {
                throw new ArgumentException($"Invalid animation type: {animationType.GetType()}");
            }

            if (AnimationsInstance == null)
            {
                AnimationsInstance = new SegmentAnimations();
                ExtraMaterialRefs.Add(AnimationsInstance.AnimationId);
            }

            AnimationsInstance.AddAnimation(new TextAnimation(meta, animationType, start, dur));
            return this;
        }

        public TextSegment AddBubble(string effectId, string resourceId)
        {
            Bubble = new TextBubble(effectId, resourceId);
            ExtraMaterialRefs.Add(Bubble.GlobalId);
            return this;
        }

        public TextSegment AddEffect(string effectId)
        {
            Effect = new TextEffect(effectId, effectId);
            ExtraMaterialRefs.Add(Effect.GlobalId);
            return this;
        }

        public Dictionary<string, object> ExportMaterial()
        {
            int checkFlag = 7;
            if (Border != null) checkFlag |= 8;
            if (Background != null) checkFlag |= 16;

            var styleJson = new Dictionary<string, object>
            {
                ["fill"] = new Dictionary<string, object>
                {
                    ["alpha"] = 1.0,
                    ["content"] = new Dictionary<string, object>
                    {
                        ["render_type"] = "solid",
                        ["solid"] = new Dictionary<string, object>
                        {
                            ["alpha"] = Style.Alpha,
                            ["color"] = Style.Color.ToList()
                        }
                    }
                },
                ["range"] = new List<int> { 0, Text.Length },
                ["size"] = Style.Size,
                ["bold"] = Style.Bold,
                ["italic"] = Style.Italic,
                ["underline"] = Style.Underline,
                ["strokes"] = Border != null ? new List<object> { Border.ExportJson() } : new List<object>()
            };

            if (Font != null)
            {
                styleJson["font"] = new Dictionary<string, object>
                {
                    ["id"] = Font.ResourceId,
                    ["path"] = $"C:/{Font.Name}.ttf"
                };
            }

            if (Effect != null)
            {
                styleJson["effectStyle"] = new Dictionary<string, object>
                {
                    ["id"] = Effect.EffectId,
                    ["path"] = "C:"
                };
            }

            var content = new Dictionary<string, object>
            {
                ["styles"] = new List<object> { styleJson },
                ["text"] = Text
            };

            var ret = new Dictionary<string, object>
            {
                ["id"] = MaterialId,
                ["content"] = JsonSerializer.Serialize(content, new JsonSerializerOptions { WriteIndented = false }),
                ["typesetting"] = Style.Vertical,
                ["alignment"] = Style.Align,
                ["letter_spacing"] = Style.LetterSpacing * 0.05,
                ["line_spacing"] = 0.02 + Style.LineSpacing * 0.05,
                ["line_feed"] = 1,
                ["line_max_width"] = 0.82,
                ["force_apply_line_max_width"] = false,
                ["check_flag"] = checkFlag,
                ["type"] = "text"
            };

            if (Background != null)
            {
                foreach (var kvp in Background.ExportJson())
                {
                    ret[kvp.Key] = kvp.Value;
                }
            }

            return ret;
        }
    }
}
