using NPOI.HPSF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    // 导入的片段
    public class ImportedSegment : BaseSegment
    {
        // 原始json数据
        public Dictionary<string, object> raw_data;

        public string material_id { get; set; }
        public Timerange target_timerange { get; set; }

        private static readonly string[] DATA_ATTRS = { "material_id", "target_timerange" };

        public ImportedSegment(Dictionary<string, object> jsonData)
            : base(
                jsonData.ContainsKey("material_id") ? jsonData["material_id"]?.ToString() : null,
                jsonData.ContainsKey("target_timerange") ? Timerange.ImportJson(jsonData["target_timerange"].ToString()) : null
              )
        {
            // 深拷贝原始数据
            raw_data = new Dictionary<string, object>(jsonData);

            // 赋值属性
            this.material_id = jsonData.ContainsKey("material_id") ? jsonData["material_id"].ToString() : null;
            this.target_timerange = jsonData.ContainsKey("target_timerange") ? Timerange.ImportJson(jsonData["target_timerange"].ToString()) : null;
        }

        public override Dictionary<string, object> ExportJson()
        {
            var jsonData = new Dictionary<string, object>(raw_data);
            jsonData["material_id"] = this.material_id;
            jsonData["target_timerange"] = this.target_timerange != null ? this.target_timerange.ToString() : null;
            return jsonData;
        }
    }

    // 导入的视频/音频片段
    public class ImportedMediaSegment : ImportedSegment
    {
        public Timerange SourceTimerange { get; set; }
        private static readonly List<string> DATA_ATTRS = new List<string> { "source_timerange" };

        public ImportedMediaSegment(Dictionary<string, object> jsonData) : base(jsonData)
        {
            Util.AssignAttrWithJson(this, DATA_ATTRS, jsonData);
        }

        public override Dictionary<string, object> ExportJson()
        {
            var jsonData = base.ExportJson();
            Util.ExportAttrToJson(jsonData, DATA_ATTRS);
            return jsonData;
        }
    }

    // 模板模式下导入的轨道
    public class ImportedTrack : BaseTrack
    {
        public Dictionary<string, object> RawData { get; set; }

        public ImportedTrack(Dictionary<string, object> jsonData)
        {
            //this.TrackType = TrackType.Meta[ TrackType.FromName(jsonData["type"].ToString())];
            this.Name = jsonData["name"].ToString();
            this.TrackId = jsonData["id"].ToString();
            this.RenderIndex = jsonData.ContainsKey("segments") && jsonData["segments"] is List<object> segments && segments.Count > 0
                ? segments.Select(seg => Convert.ToInt32(((Dictionary<string, object>)seg)["render_index"])).Max()
                : 0;
            this.RawData = new Dictionary<string, object>(jsonData);
        }

        public override Dictionary<string, object> ExportJson()
        {
            var ret = new Dictionary<string, object>(RawData);
            ret["name"] = this.Name;
            ret["id"] = this.TrackId;
            return ret;
        }
    }

    // 模板模式下导入且可修改的轨道(音视频及文本轨道)
    public class EditableTrack : ImportedTrack
    {
        public List<ImportedSegment> Segments { get; set; } = new List<ImportedSegment>();

        public EditableTrack(Dictionary<string, object> jsonData) : base(jsonData) { }

        public int Count => Segments.Count;

        public long StartTime => Segments.Count == 0 ? 0 : ((dynamic)Segments[0]).target_timerange.start;

        public long EndTime => Segments.Count == 0 ? 0 : ((dynamic)Segments.Last()).target_timerange.end;

        public override Dictionary<string, object> ExportJson()
        {
            var ret = base.ExportJson();
            var segmentExports = new List<Dictionary<string, object>>();
            foreach (var seg in Segments)
            {
                var segJson = seg.ExportJson();
                segJson["render_index"] = this.RenderIndex;
                segmentExports.Add(segJson);
            }
            ret["segments"] = segmentExports;
            return ret;
        }
    }

    // 模板模式下导入的文本轨道
    public class ImportedTextTrack : EditableTrack
    {
        public ImportedTextTrack(Dictionary<string, object> jsonData) : base(jsonData)
        {
            if (jsonData.ContainsKey("segments") && jsonData["segments"] is List<object> segments)
            {
                this.Segments = segments.Select(seg => new ImportedSegment((Dictionary<string, object>)seg)).ToList();
            }
        }
    }

    // 模板模式下导入的音频/视频轨道
    public class ImportedMediaTrack : EditableTrack
    {
        public new List<ImportedMediaSegment> Segments { get; set; } = new List<ImportedMediaSegment>();

        public ImportedMediaTrack(Dictionary<string, object> jsonData) : base(jsonData)
        {
            if (jsonData.ContainsKey("segments") && jsonData["segments"] is List<object> segments)
            {
                this.Segments = segments.Select(seg => new ImportedMediaSegment((Dictionary<string, object>)seg)).ToList();
            }
        }

        // 检查素材类型是否与轨道类型匹配
        public bool CheckMaterialType(object material)
        {
            if (this.Name == "video" && material is VideoMaterial)
                return true;
            if (this.Name == "audio" && material is AudioMaterial)
                return true;
            return false;
        }

        // 处理素材替换的时间范围变更
        public void ProcessTimerange(int segIndex, Timerange srcTimerange, ShrinkMode shrink, List<ExtendMode> extend)
        {
            var seg = this.Segments[segIndex];
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
                        for (int i = segIndex + 1; i < this.Segments.Count; i++)
                            this.Segments[i].Start -= deltaDuration;
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
                long prevSegEnd = segIndex == 0 ? 0 : ((dynamic)this.Segments[segIndex - 1]).target_timerange.end;
                long nextSegStart = segIndex == this.Segments.Count - 1 ? int.MaxValue : this.Segments[segIndex + 1].Start;
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
                                for (int i = segIndex + 1; i < this.Segments.Count; i++)
                                    this.Segments[i].Start += shiftDuration;
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

    // 导入轨道
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
