using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft
{
    /// <summary>
    /// 辅助函数，主要与模板模式有关
    /// </summary>
    public static class Util
    {
        // JsonExportable 的 C# 近似类型
        public interface IJsonExportable
        {
            object ExportJson();
            void ImportJson(object data);
        }

        /// <summary>
        /// 为构造函数提供默认值，以绕开构造函数的参数限制
        /// </summary>
        public static Dictionary<string, object> ProvideCtorDefaults(Type type)
        {
            var providedDefaults = new Dictionary<string, object>();
            var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, CallingConventions.Any,
                Array.ConvertAll(type.GetConstructors()[0].GetParameters(), p => p.ParameterType), null);

            if (ctor == null)
                throw new InvalidOperationException("No constructor found.");

            foreach (var param in ctor.GetParameters())
            {
                if (param.HasDefaultValue) continue;

                if (param.ParameterType == typeof(int) || param.ParameterType == typeof(float) || param.ParameterType == typeof(double))
                {
                    providedDefaults[param.Name] = 0;
                }
                else if (param.ParameterType == typeof(string))
                {
                    providedDefaults[param.Name] = "";
                }
                else if (param.ParameterType == typeof(bool))
                {
                    providedDefaults[param.Name] = false;
                }
                else
                {
                    throw new Exception($"Unsupported parameter type: {param.ParameterType}");
                }
            }
            return providedDefaults;
        }

        /// <summary>
        /// 根据json数据赋值给指定的对象属性
        /// 若有复杂类型，则尝试调用其 ImportJson 方法进行构造
        /// </summary>
        public static void AssignAttrWithJson(object obj, List<string> attrs, Dictionary<string, object> jsonData)
        {
            var type = obj.GetType();
            foreach (var attr in attrs)
            {
                var prop = type.GetProperty(attr, BindingFlags.Public | BindingFlags.Instance);
                if (prop == null) continue;

                var propType = prop.PropertyType;
                if (typeof(IJsonExportable).IsAssignableFrom(propType))
                {
                    var instance = (IJsonExportable)Activator.CreateInstance(propType);
                    instance.ImportJson(jsonData[attr]);
                    prop.SetValue(obj, instance);
                }
                else
                {
                    prop.SetValue(obj, Convert.ChangeType(jsonData[attr], propType));
                }
            }
        }

        /// <summary>
        /// 将对象属性导出为json数据
        /// 若有复杂类型，则尝试调用其 ExportJson 方法进行导出
        /// </summary>
        public static Dictionary<string, object> ExportAttrToJson(object obj, List<string> attrs)
        {
            var jsonData = new Dictionary<string, object>();
            var type = obj.GetType();
            foreach (var attr in attrs)
            {
                var prop = type.GetProperty(attr, BindingFlags.Public | BindingFlags.Instance);
                if (prop == null) continue;

                var value = prop.GetValue(obj);
                if (value is IJsonExportable exportable)
                {
                    jsonData[attr] = exportable.ExportJson();
                }
                else
                {
                    jsonData[attr] = value;
                }
            }
            return jsonData;
        }
    }
}
