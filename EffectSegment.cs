using JyDraft.meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JyDraft.TimeUtil;

namespace JyDraft
{
    /// <summary>
    /// 放置在独立特效轨道上的特效片段
    /// </summary>
    public class EffectSegment : BaseSegment
    {
        /// <summary>相应的特效素材，在放入轨道时自动添加到素材列表中</summary>
        public VideoEffect EffectInstance { get; private set; }

        public EffectSegment(
            EffectMeta effectType,  // 联合类型的接口（见下方解释）
            Timerange targetTimerange,
            List<float?> parameters = null)
            : base(null, targetTimerange) // 会在后面设置 globalId
        {
            EffectInstance = new VideoEffect(effectType, parameters, applyTargetType: 2); // 2 表示全局作用域
            this.MaterialId = EffectInstance.GlobalId; // 调用父类属性
        }
    }

    /// <summary>
    /// 放置在独立滤镜轨道上的滤镜片段
    /// </summary>
    public class FilterSegment : BaseSegment
    {
        /// <summary>
        /// 相应的滤镜素材
        /// 在放入轨道时自动添加到素材列表中
        /// </summary>
        public Filter Material { get; private set; }

        public FilterSegment(
            EffectMeta meta,
            Timerange targetTimerange,
            float intensity
        ) : base(null, targetTimerange)
        {
            Material = new Filter(meta, intensity);
            this.MaterialId = Material.GlobalId;
        }
    }
}
