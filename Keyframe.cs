using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JyDraft
{
    // 一个关键帧（关键点），目前只支持线性插值
    public class Keyframe
    {
        // 关键帧全局id, 自动生成
        public string Id { get; }
        // 相对于素材起始点的时间偏移量
        public int TimeOffset { get; }
        // 关键帧的值, 似乎一般只有一个元素
        public List<float> Values { get; }

        public Keyframe(int timeOffset, float value)
        {
            Id = Guid.NewGuid().ToString();
            TimeOffset = timeOffset;
            Values = new List<float> { value };
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
        {
            // 默认值
            { "curveType", "Line" },
            { "graphID", "" },
            { "left_control", new Dictionary<string, float> { { "x", 0.0f }, { "y", 0.0f } } },
            { "right_control", new Dictionary<string, float> { { "x", 0.0f }, { "y", 0.0f } } },
            // 自定义属性
            { "id", Id },
            { "time_offset", TimeOffset },
            { "values", Values }
        };
        }
    }

    // 关键帧所控制的属性类型
    public enum KeyframeProperty
    {
        // 右移为正, 单位是半个画布宽
        [JsonPropertyName("KFTypePositionX")]
        PositionX,
        // 上移为正, 单位是半个画布高
        [JsonPropertyName("KFTypePositionY")]
        PositionY,
        // 顺时针旋转的角度
        [JsonPropertyName("KFTypeRotation")]
        Rotation,
        // 单独控制X轴缩放比例
        [JsonPropertyName("KFTypeScaleX")]
        ScaleX,
        // 单独控制Y轴缩放比例
        [JsonPropertyName("KFTypeScaleY")]
        ScaleY,
        // 同时控制X轴及Y轴缩放比例
        [JsonPropertyName("UNIFORM_SCALE")]
        UniformScale,
        // 不透明度
        [JsonPropertyName("KFTypeAlpha")]
        Alpha,
        // 饱和度
        [JsonPropertyName("KFTypeSaturation")]
        Saturation,
        // 对比度
        [JsonPropertyName("KFTypeContrast")]
        Contrast,
        // 亮度
        [JsonPropertyName("KFTypeBrightness")]
        Brightness,
        // 音量
        [JsonPropertyName("KFTypeVolume")]
        Volume
    }

    // 关键帧列表, 记录与某个特定属性相关的一系列关键帧
    public class KeyframeList
    {
        // 关键帧列表全局id, 自动生成
        public string Id { get; }
        // 关键帧对应的属性
        public KeyframeProperty Property { get; }
        // 关键帧列表
        public List<Keyframe> Keyframes { get; }

        public KeyframeList(KeyframeProperty property)
        {
            Id = Guid.NewGuid().ToString();
            Property = property;
            Keyframes = new List<Keyframe>();
        }

        // 给定时间偏移量及关键值, 向此关键帧列表中添加一个关键帧
        public void AddKeyframe(int timeOffset, float value)
        {
            var kf = new Keyframe(timeOffset, value);
            Keyframes.Add(kf);
            Keyframes.Sort((a, b) => a.TimeOffset.CompareTo(b.TimeOffset));
        }

        public Dictionary<string, object> ExportJson()
        {
            var keyframeListJson = new List<Dictionary<string, object>>();
            foreach (var kf in Keyframes)
            {
                keyframeListJson.Add(kf.ExportJson());
            }

            return new Dictionary<string, object>
        {
            { "id", Id },
            { "keyframe_list", keyframeListJson },
            { "material_id", "" },
            { "property_type", Property.ToString() }
        };
        }
    }
}
