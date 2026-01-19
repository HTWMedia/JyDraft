using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft.meta
{
    /// <summary>
    /// 蒙版元数据
    /// </summary>
    public class MaskMeta
    {
        /// <summary>
        /// 转场名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 资源类型, 与蒙版形状相关
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// 效果ID
        /// </summary>
        public string EffectId { get; set; }

        /// <summary>
        /// MD5
        /// </summary>
        public string Md5 { get; set; }

        /// <summary>
        /// 默认宽高比(宽高都是相对素材的比例)
        /// </summary>
        public double DefaultAspectRatio { get; set; }

        public MaskMeta(
            string name,
            string resourceType,
            string resourceId,
            string effectId,
            string md5,
            double defaultAspectRatio)
        {
            Name = name;
            ResourceType = resourceType;
            ResourceId = resourceId;
            EffectId = effectId;
            Md5 = md5;
            DefaultAspectRatio = defaultAspectRatio;
        }
    }

    /// <summary>
    /// 蒙版类型
    /// </summary>
    public static class MaskType 
    {
        /// <summary>默认遮挡下方部分</summary>
        public static readonly MaskMeta 线性 = new MaskMeta("线性", "line", "6791652175668843016", "636071", "1f467b8b9bb94cecc46d916219b7940a", 1.0);

        /// <summary>默认保留两线之间部分</summary>
        public static readonly MaskMeta 镜面 = new MaskMeta("镜面", "mirror", "6791699060140020232", "636073", "b2c0516d1f737f4542fb9b2862907817", 1.0);

        public static readonly MaskMeta 圆形 = new MaskMeta("圆形", "circle", "6791700663249146381", "636075", "9a55eae0e99ee6d1ecbc6defaf0501ec", 1.0);
        public static readonly MaskMeta 矩形 = new MaskMeta("矩形", "rectangle", "6791700809454195207", "636077", "ef361d96c456cd6077c76d737f98898d", 1.0);
        public static readonly MaskMeta 爱心 = new MaskMeta("爱心", "geometric_shape", "6794051276482023949", "636079", "0bf09fa1e3a32464fed4f71e49a8ab01", 1.115);
        public static readonly MaskMeta 星形 = new MaskMeta("星形", "geometric_shape", "6794051169434997255", "636081", "155612dee601d3f5422a3fbeabc7610c", 1.05);
    }
}
