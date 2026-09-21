using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using static JyDraft.TimeUtil;

namespace JyDraft
{
    // 处理替换素材时素材变短情况的方法
    public enum ShrinkMode
    {
        CutHead,        // 裁剪头部
        CutTail,        // 裁剪尾部
        CutTailAlign,   // 裁剪尾部并消除间隙
        Shrink          // 保持中间点不变，两端点向中间靠拢
    }

    // 处理替换素材时素材变长情况的方法
    public enum ExtendMode
    {
        CutMaterialTail,    // 裁剪素材尾部
        ExtendHead,         // 延伸头部
        ExtendTail,         // 延伸尾部
        PushTail            // 延伸尾部并后移后续片段
    }

    /// <summary>导入（模板模式）的片段</summary>
    public class ImportedSegment : BaseSegment
    {
        // 原始 json 数据
        public Dictionary<string, object> raw_data;

        /// <summary>
        /// 与基类 <see cref="BaseSegment.MaterialId"/> 是同一份状态。
        /// 原先这里另存一份，导致改写基类属性后导出时读到的还是旧值。
        /// </summary>
        public string material_id
        {
            get => MaterialId;
            set => MaterialId = value;
        }

        /// <summary>与基类 <see cref="BaseSegment.TargetTimerange"/> 是同一份状态</summary>
        public Timerange target_timerange
        {
            get => TargetTimerange;
            set => TargetTimerange = value;
        }

        public ImportedSegment(Dictionary<string, object> jsonData)
            : base(
                jsonData.ContainsKey("material_id") ? jsonData["material_id"]?.ToString() : null,
                jsonData.ContainsKey("target_timerange") ? Timerange.ImportJson(jsonData["target_timerange"]) : null
              )
        {
            // 保留原始数据
            raw_data = new Dictionary<string, object>(jsonData);
        }

        public override Dictionary<string, object> ExportJson()
        {
            var jsonData = new Dictionary<string, object>(raw_data);
            jsonData["material_id"] = MaterialId;
            jsonData["target_timerange"] = TargetTimerange?.ToString();
            return jsonData;
        }
    }

    /// <summary>导入的音频 / 视频片段（比 ImportedSegment 多一个素材区间）</summary>
    public class ImportedMediaSegment : ImportedSegment
    {
        public Timerange SourceTimerange { get; set; }

        public ImportedMediaSegment(Dictionary<string, object> jsonData) : base(jsonData)
        {
            // 原实现走 Util.AssignAttrWithJson：Timerange 不实现 Util.IJsonExportable，
            // 会掉进 Convert.ChangeType(JObject, Timerange) 直接抛异常
            if (jsonData.TryGetValue("source_timerange", out var raw) && raw != null)
                SourceTimerange = Timerange.ImportJson(raw);
        }

        public override Dictionary<string, object> ExportJson()
        {
            var jsonData = base.ExportJson();
            jsonData["source_timerange"] = SourceTimerange?.ToString();
            return jsonData;
        }
    }

    /// <summary>模板模式下导入的轨道</summary>
    public class ImportedTrack : BaseTrack
    {
        public Dictionary<string, object> RawData { get; }

        public ImportedTrack(Dictionary<string, object> jsonData)
        {
            // 原先这里没解析 type，导致所有导入轨道的 TrackTypeName 都是默认值 video
            TrackTypeName = TrackType.FromName(jsonData["type"].ToString());
            Name = jsonData["name"].ToString();
            TrackId = jsonData["id"].ToString();
            var segs = ReadSegments(jsonData);
            RenderIndex = segs.Count > 0 ? segs.Max(s => Convert.ToInt32(s.GetValueOrDefault("render_index", 0))) : 0;
            RawData = new Dictionary<string, object>(jsonData);
        }

        /// <summary>
        /// 读取轨道里的片段列表。ToObject&lt;Dictionary&gt; 会把嵌套数组还原成 JArray，
        /// 原实现只认 List&lt;object&gt;，结果片段永远是空的。
        /// </summary>
        internal static List<Dictionary<string, object>> ReadSegments(Dictionary<string, object> jsonData)
        {
            var result = new List<Dictionary<string, object>>();
            if (!jsonData.TryGetValue("segments", out var raw) || raw == null) return result;

            if (raw is IEnumerable<object> list)
            {
                foreach (var item in list)
                {
                    if (item is Dictionary<string, object> dict) result.Add(dict);
                    else if (item is JToken token) result.Add(token.ToObject<Dictionary<string, object>>());
                }
            }
            else if (raw is JArray array)
            {
                foreach (var token in array)
                    result.Add(token.ToObject<Dictionary<string, object>>());
            }
            return result;
        }

        public override void AddSegment(BaseSegment segment)
            => throw new NotSupportedException("导入的轨道不支持添加片段");

        public override Dictionary<string, object> ExportJson()
        {
            var ret = new Dictionary<string, object>(RawData);
            ret["name"] = Name;
            ret["id"] = TrackId;
            return ret;
        }
    }

    /// <summary>
    /// 可编辑的导入轨道。非泛型基类只暴露「与片段具体类型无关」的能力，
    /// 具体片段列表由 <see cref="EditableTrack{TSegment}"/> 持有——
    /// 原先 ImportedMediaTrack 用 <c>new</c> 另开一份 Segments，
    /// 基类的 ExportJson 遍历的却是空列表，导入的媒体轨道导出时片段会整段丢失。
    /// </summary>
    public abstract class EditableTrack : ImportedTrack
    {
        protected EditableTrack(Dictionary<string, object> jsonData) : base(jsonData) { }

        public abstract int Count { get; }
        public abstract long StartTime { get; }
        public abstract long EndTime { get; }

        /// <summary>以基类视角访问片段，供不需要知道具体片段类型的逻辑使用</summary>
        public abstract IReadOnlyList<ImportedSegment> AllSegments { get; }
    }

    public abstract class EditableTrack<TSegment> : EditableTrack where TSegment : ImportedSegment
    {
        public List<TSegment> Segments { get; } = new List<TSegment>();

        protected EditableTrack(Dictionary<string, object> jsonData) : base(jsonData) { }

        public override int Count => Segments.Count;
        public override long StartTime => Segments.Count == 0 ? 0 : Segments[0].TargetTimerange.Start;
        public override long EndTime => Segments.Count == 0 ? 0 : Segments[^1].TargetTimerange.End;
        public override IReadOnlyList<ImportedSegment> AllSegments => Segments;

        public override void AddSegment(BaseSegment segment)
            => throw new NotSupportedException("导入的轨道不支持添加片段");

        public override Dictionary<string, object> ExportJson()
        {
            var ret = base.ExportJson();
            ret["segments"] = Segments.Select(seg =>
            {
                var segJson = seg.ExportJson();
                segJson["render_index"] = RenderIndex;
                return segJson;
            }).ToList();
            return ret;
        }
    }

    /// <summary>模板模式下导入的文本轨道</summary>
    public class ImportedTextTrack : EditableTrack<ImportedSegment>
    {
        public ImportedTextTrack(Dictionary<string, object> jsonData) : base(jsonData)
        {
            Segments.AddRange(ReadSegments(jsonData).Select(seg => new ImportedSegment(seg)));
        }
    }

    /// <summary>模板模式下导入的音频 / 视频轨道</summary>
    public class ImportedMediaTrack : EditableTrack<ImportedMediaSegment>
    {
        public ImportedMediaTrack(Dictionary<string, object> jsonData) : base(jsonData)
        {
            Segments.AddRange(ReadSegments(jsonData).Select(seg => new ImportedMediaSegment(seg)));
        }

        // 检查素材类型是否与轨道类型匹配
        public bool CheckMaterialType(object material)
        {
            if (Name == "video" && material is VideoMaterial) return true;
            if (Name == "audio" && material is AudioMaterial) return true;
            return false;
        }

        // 处理素材替换的时间范围变更
        public void ProcessTimerange(int segIndex, Timerange srcTimerange, ShrinkMode shrink, List<ExtendMode> extend)
        {
            var seg = Segments[segIndex];
            var newDuration = srcTimerange.Duration;
            var deltaDuration = Math.Abs(newDuration - seg.Duration);

            // 时长变短
            if (newDuration < seg.Duration)
            {
                switch (shrink)
                {
                    case ShrinkMode.CutHead:
                        seg.Start += deltaDuration;
                        break;
                    case ShrinkMode.CutTail:
                        seg.Duration -= deltaDuration;
                        break;
                    case ShrinkMode.CutTailAlign:
                        seg.Duration -= deltaDuration;
                        for (int i = segIndex + 1; i < Segments.Count; i++)
                            Segments[i].Start -= deltaDuration;
                        break;
                    case ShrinkMode.Shrink:
                        seg.Duration -= deltaDuration;
                        seg.Start += deltaDuration / 2;
                        break;
                    default:
                        throw new ArgumentException($"Unsupported shrink mode: {shrink}");
                }
            }
            // 时长变长
            else if (newDuration > seg.Duration)
            {
                bool successFlag = false;
                long prevSegEnd = segIndex == 0 ? 0 : Segments[segIndex - 1].TargetTimerange.End;
                long nextSegStart = segIndex == Segments.Count - 1 ? int.MaxValue : Segments[segIndex + 1].Start;
                foreach (var mode in extend)
                {
                    switch (mode)
                    {
                        case ExtendMode.ExtendHead:
                            if (seg.Start - deltaDuration >= prevSegEnd)
                            {
                                seg.Start -= deltaDuration;
                                successFlag = true;
                            }
                            break;
                        case ExtendMode.ExtendTail:
                            if (seg.TargetTimerange.End + deltaDuration <= nextSegStart)
                            {
                                seg.Duration += deltaDuration;
                                successFlag = true;
                            }
                            break;
                        case ExtendMode.PushTail:
                            long shiftDuration = Math.Max(0, seg.TargetTimerange.End + deltaDuration - nextSegStart);
                            seg.Duration += deltaDuration;
                            if (shiftDuration > 0)
                            {
                                for (int i = segIndex + 1; i < Segments.Count; i++)
                                    Segments[i].Start += shiftDuration;
                            }
                            successFlag = true;
                            break;
                        case ExtendMode.CutMaterialTail:
                            srcTimerange.Duration = seg.Duration;
                            successFlag = true;
                            break;
                        default:
                            throw new ArgumentException($"Unsupported extend mode: {mode}");
                    }
                    if (successFlag) break;
                }
                if (!successFlag)
                {
                    throw new Exception($"未能将片段延长至 {newDuration}μs, 尝试过以下方法: {string.Join(",", extend)}");
                }
            }
            // 写入素材时间范围
            seg.SourceTimerange = srcTimerange;
        }
    }

    /// <summary>导入轨道的工厂：按轨道类型决定能不能编辑、片段用哪种类型</summary>
    public static class TrackImporter
    {
        public static ImportedTrack ImportTrack(Dictionary<string, object> jsonData)
        {
            var trackType = TrackType.FromName(jsonData["type"].ToString());
            if (!TrackType.Meta[trackType].AllowModify)
                return new ImportedTrack(jsonData);
            if (trackType == TrackTypeName.text)
                return new ImportedTextTrack(jsonData);
            return new ImportedMediaTrack(jsonData);
        }
    }
}
