using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft.meta
{
    /// <summary>
    /// 特效参数信息
    /// </summary>
    public class EffectParam
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public double DefaultValue { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public double MaxValue { get; set; }

        public EffectParam(string name, double defaultValue, double minValue, double maxValue)
        {
            Name = name;
            DefaultValue = defaultValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }

    /// <summary>
    /// 特效参数实例
    /// </summary>
    public class EffectParamInstance : EffectParam
    {
        /// <summary>
        /// 参数索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 当前值
        /// </summary>
        public double Value { get; set; }

        public EffectParamInstance(EffectParam meta, int index, double value)
            : base(meta.Name, meta.DefaultValue, meta.MinValue, meta.MaxValue)
        {
            Index = index;
            Value = value;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "default_value", DefaultValue },
                { "max_value", MaxValue },
                { "min_value", MinValue },
                { "name", Name },
                { "parameterIndex", Index },
                { "portIndex", 0 },
                { "value", Value }
            };
        }
    }

    /// <summary>
    /// 特效元数据
    /// </summary>
    public class EffectMeta
    {
        /// <summary>
        /// 效果名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否为VIP特权
        /// </summary>
        public bool IsVip { get; set; }
        /// <summary>
        /// 资源ID
        /// </summary>
        public string ResourceId { get; set; }
        /// <summary>
        /// 效果ID
        /// </summary>
        public string EffectId { get; set; }
        /// <summary>
        /// 文件MD5
        /// </summary>
        public string Md5 { get; set; }
        /// <summary>
        /// 效果的参数信息
        /// </summary>
        public List<EffectParam> Params { get; set; }

        public EffectMeta(string name, bool isVip, string resourceId, string effectId, string md5, List<EffectParam>? parameters = null)
        {
            Name = name;
            IsVip = isVip;
            ResourceId = resourceId;
            EffectId = effectId;
            Md5 = md5;
            Params = parameters ?? new List<EffectParam>();
        }

        /// <summary>
        /// 解析参数列表（范围0~100），返回参数实例列表
        /// </summary>
        public List<EffectParamInstance> ParseParams(List<float?>? paramValues)
        {
            var result = new List<EffectParamInstance>();
            if (paramValues == null)
                paramValues = new List<float?>();

            for (int i = 0; i < Params.Count; i++)
            {
                var param = Params[i];
                double val = param.DefaultValue;
                if (i < paramValues.Count)
                {
                    var inputVal = paramValues[i];
                    if (inputVal.HasValue)
                    {
                        if (inputVal.Value < 0 || inputVal.Value > 100)
                            throw new ArgumentOutOfRangeException($"Invalid parameter value {inputVal.Value} within {param.Name}");
                        val = param.MinValue + (param.MaxValue - param.MinValue) * inputVal.Value / 100.0;
                    }
                }
                result.Add(new EffectParamInstance(param, i, val));
            }

            return result;
        }
    }
}
