using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.Util;
using JyDraft.meta;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static JyDraft.TimeUtil;

namespace JyDraft
{
    public class ScriptMaterial
    {
        public List<AudioMaterial> Audios { get; set; }
        public List<VideoMaterial> Videos { get; set; }
        public List<Dictionary<string, object>> Stickers { get; set; }
        public List<Dictionary<string, object>> Texts { get; set; }

        public List<AudioEffect> AudioEffects { get; set; }
        public List<AudioFade> AudioFades { get; set; }
        public List<SegmentAnimations> Animations { get; set; }
        public List<VideoEffect> VideoEffects { get; set; }

        public List<Speed> Speeds { get; set; }
        public List<Dictionary<string, object>> Masks { get; set; }
        public List<Transition> Transitions { get; set; }
        public List<object> Filters { get; set; } // Could be Filter or TextBubble
        public List<BackgroundFilling> Canvases { get; set; }

        public ScriptMaterial()
        {
            Audios = new List<AudioMaterial>();
            Videos = new List<VideoMaterial>();
            Stickers = new List<Dictionary<string, object>>();
            Texts = new List<Dictionary<string, object>>();

            AudioEffects = new List<AudioEffect>();
            AudioFades = new List<AudioFade>();
            Animations = new List<SegmentAnimations>();
            VideoEffects = new List<VideoEffect>();

            Speeds = new List<Speed>();
            Masks = new List<Dictionary<string, object>>();
            Transitions = new List<Transition>();
            Filters = new List<object>();
            Canvases = new List<BackgroundFilling>();
        }

        public bool Contains(object item)
        {
            switch (item)
            {
                case VideoMaterial video:
                    return Videos.Any(v => v.MaterialId == video.MaterialId);
                case AudioMaterial audio:
                    return Audios.Any(a => a.MaterialId == audio.MaterialId);
                case AudioFade fade:
                    return AudioFades.Any(f => f.FadeId == fade.FadeId);
                case AudioEffect effect:
                    return AudioEffects.Any(e => e.EffectId == effect.EffectId);
                case SegmentAnimations animation:
                    return Animations.Any(a => a.AnimationId == animation.AnimationId);
                case VideoEffect videoEffect:
                    return VideoEffects.Any(v => v.GlobalId == videoEffect.GlobalId);
                case Transition transition:
                    return Transitions.Any(t => t.GlobalId == transition.GlobalId);
                case Filter filter:
                    return Filters.OfType<Filter>().Any(f => f.GlobalId == filter.GlobalId);
                default:
                    throw new ArgumentException($"Invalid argument type '{item.GetType()}'");
            }
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                ["ai_translates"] = new List<object>(),
                ["audio_balances"] = new List<object>(),
                ["audio_effects"] = AudioEffects.Select(e => e.ExportJson()).ToList(),
                ["audio_fades"] = AudioFades.Select(f => f.ExportJson()).ToList(),
                ["audio_track_indexes"] = new List<object>(),
                ["audios"] = Audios.Select(a => a.ExportJson()).ToList(),
                ["beats"] = new List<object>(),
                ["canvases"] = Canvases.Select(c => c.ExportJson()).ToList(),
                ["chromas"] = new List<object>(),
                ["color_curves"] = new List<object>(),
                ["digital_humans"] = new List<object>(),
                ["drafts"] = new List<object>(),
                ["effects"] = Filters.Select(f =>
                    (f as Filter)?.ExportJson() ?? (f as TextBubble)?.ExportJson()).ToList(),
                ["flowers"] = new List<object>(),
                ["green_screens"] = new List<object>(),
                ["handwrites"] = new List<object>(),
                ["hsl"] = new List<object>(),
                ["images"] = new List<object>(),
                ["log_color_wheels"] = new List<object>(),
                ["loudnesses"] = new List<object>(),
                ["manual_deformations"] = new List<object>(),
                ["masks"] = Masks,
                ["material_animations"] = Animations.Select(a => a.ExportJson()).ToList(),
                ["material_colors"] = new List<object>(),
                ["multi_language_refs"] = new List<object>(),
                ["placeholders"] = new List<object>(),
                ["plugin_effects"] = new List<object>(),
                ["primary_color_wheels"] = new List<object>(),
                ["realtime_denoises"] = new List<object>(),
                ["shapes"] = new List<object>(),
                ["smart_crops"] = new List<object>(),
                ["smart_relights"] = new List<object>(),
                ["sound_channel_mappings"] = new List<object>(),
                ["speeds"] = Speeds.Select(s => s.ExportJson()).ToList(),
                ["stickers"] = Stickers,
                ["tail_leaders"] = new List<object>(),
                ["text_templates"] = new List<object>(),
                ["texts"] = Texts,
                ["time_marks"] = new List<object>(),
                ["transitions"] = Transitions.Select(t => t.ExportJson()).ToList(),
                ["video_effects"] = VideoEffects.Select(v => v.ExportJson()).ToList(),
                ["video_trackings"] = new List<object>(),
                ["videos"] = Videos.Select(v => v.ExportJson()).ToList(),
                ["vocal_beautifys"] = new List<object>(),
                ["vocal_separations"] = new List<object>()
            };
        }
    }


    public class ScriptFile
    {
        public string? SavePath { get; set; }
        public JObject Content { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Fps { get; set; }
        public long Duration { get; set; }

        public ScriptMaterial Materials { get; set; }
        public Dictionary<string, BaseTrack> Tracks { get; set; }

        public Dictionary<string, List<Dictionary<string, object>>> ImportedMaterials { get; set; }
        public List<ImportedTrack> ImportedTracks { get; set; }

        private const string TEMPLATE_FILE = "draft_content_template.json";

        public ScriptFile(int width, int height, int fps = 30)
        {
            Width = width;
            Height = height;
            Fps = fps;
            Duration = 0;

            SavePath = null;
            Materials = new ScriptMaterial();
            Tracks = new Dictionary<string, BaseTrack>();
            ImportedMaterials = new Dictionary<string, List<Dictionary<string, object>>>();
            ImportedTracks = new List<ImportedTrack>();

            string templatePath = Path.Combine(AppContext.BaseDirectory, TEMPLATE_FILE);
            Content = JObject.Parse(File.ReadAllText(templatePath));
        }

        public static ScriptFile LoadTemplate(string jsonPath)
        {
            if (!File.Exists(jsonPath))
                throw new FileNotFoundException($"JSON 文件 '{jsonPath}' 不存在");

            var json = JObject.Parse(File.ReadAllText(jsonPath));
            var width = json["canvas_config"]?["width"]?.Value<int>() ?? 0;
            var height = json["canvas_config"]?["height"]?.Value<int>() ?? 0;
            var fps = json["fps"]?.Value<int>() ?? 30;
            var duration = json["duration"]?.Value<int>() ?? 0;

            var file = new ScriptFile(width, height, fps)
            {
                SavePath = jsonPath,
                Duration = duration,
                Content = json,
                ImportedMaterials = json["materials"]?.ToObject<Dictionary<string, List<Dictionary<string, object>>>>() ?? new(),
                ImportedTracks = json["tracks"]?
            .Select(track => new ImportedTrack(track.ToObject<Dictionary<string, object>>()))
            .ToList() ?? new()
            };

            return file;
        }

        public ScriptFile AddMaterial(object material)
        {
            if (material is VideoMaterial video)
            {
                if (!Materials.Videos.Any(v => v.MaterialId == video.MaterialId))
                    Materials.Videos.Add(video);
            }
            else if (material is AudioMaterial audio)
            {
                if (!Materials.Audios.Any(a => a.MaterialId == audio.MaterialId))
                    Materials.Audios.Add(audio);
            }
            else
            {
                throw new ArgumentException($"错误的素材类型: '{material.GetType()}'");
            }

            return this;
        }

        public ScriptFile AddTrack(TrackTypeName trackTypeName, string? trackName = null, bool mute = false,
                                   int relativeIndex = 0, int? absoluteIndex = null)
        {
            if (trackName == null)
            {
                if (Tracks.Values.Any(t => t.TrackTypeName == trackTypeName))
                    throw new Exception($"'{trackTypeName}' 类型的轨道已存在, 请为新轨道指定名称以避免混淆");
                trackName = trackTypeName.ToString();
            }

            if (Tracks.ContainsKey(trackName))
                throw new Exception($"名为 '{trackName}' 的轨道已存在");

            int renderIndex = TrackType.Meta[TrackType.FromName(trackName)].RenderIndex + relativeIndex;
            if (absoluteIndex.HasValue)
                renderIndex = absoluteIndex.Value;

            // 通过 trackType 获取泛型参数 T（片段类型）
            var segmentType = TrackType.Meta[TrackType.FromName(trackName)].SegmentType;
            var genericType = typeof(Track<>).MakeGenericType(segmentType);
            var track = (BaseTrack)Activator.CreateInstance(genericType, trackTypeName, trackName, renderIndex, mute)!;

            Tracks[trackName] = track;
            return this;
        }

        public BaseTrack GetTrack(Type segmentType, string? trackName = null)
        {
            if (trackName != null)
            {
                if (!Tracks.ContainsKey(trackName))
                    throw new Exception($"不存在名为 '{trackName}' 的轨道");
                return Tracks[trackName];
            }

            var matchingTracks = Tracks.Values.Where(t => t.AcceptSegmentType == segmentType).ToList();

            if (matchingTracks.Count == 0)
                throw new Exception($"不存在接受 '{segmentType.Name}' 的轨道");
            if (matchingTracks.Count > 1)
                throw new Exception($"存在多个接受 '{segmentType.Name}' 的轨道, 请指定轨道名称");

            return matchingTracks[0];
        }

        public ScriptFile AddSegment(BaseSegment segment, string? trackName = null)
        {
            var segmentType = segment.GetType();
            var track = GetTrack(segmentType, trackName);

            // 通过反射调用泛型 AddSegment 方法
            var method = typeof(Track<>)
                .MakeGenericType(segmentType)
                .GetMethod("AddSegment")!;

            method.Invoke(track, new object[] { segment });

            Duration = Math.Max(Duration, segment.End);

            switch (segment)
            {
                case VideoSegment videoSeg:
                    if (videoSeg.AnimationsInstance != null && !Materials.Animations.Contains(videoSeg.AnimationsInstance))
                        Materials.Animations.Add(videoSeg.AnimationsInstance);

                    foreach (var effect in videoSeg.Effects)
                        if (!Materials.VideoEffects.Contains(effect))
                            Materials.VideoEffects.Add(effect);

                    foreach (var filter in videoSeg.Filters)
                        if (!Materials.Filters.Contains(filter))
                            Materials.Filters.Add(filter);

                    if (videoSeg.Mask != null)
                        Materials.Masks.Add(videoSeg.Mask.ExportJson());

                    if (videoSeg.Transition != null && !Materials.Transitions.Contains(videoSeg.Transition))
                        Materials.Transitions.Add(videoSeg.Transition);

                    if (videoSeg.BackgroundFilling != null)
                        Materials.Canvases.Add(videoSeg.BackgroundFilling);

                    Materials.Speeds.Add(videoSeg.Speed);
                    AddMaterial(videoSeg.MaterialInstance);
                    break;

                case StickerSegment stickerSeg:
                    Materials.Stickers.Add(stickerSeg.ExportMaterial());
                    break;

                case AudioSegment audioSeg:
                    if (audioSeg.Fade != null && !Materials.AudioFades.Contains(audioSeg.Fade))
                        Materials.AudioFades.Add(audioSeg.Fade);

                    foreach (var effect in audioSeg.Effects)
                        if (!Materials.AudioEffects.Contains(effect))
                            Materials.AudioEffects.Add(effect);

                    Materials.Speeds.Add(audioSeg.Speed);
                    AddMaterial(audioSeg.MaterialInstance);
                    break;

                case TextSegment textSeg:
                    if (textSeg.AnimationsInstance != null && !Materials.Animations.Contains(textSeg.AnimationsInstance))
                        Materials.Animations.Add(textSeg.AnimationsInstance);

                    if (textSeg.Bubble != null)
                        Materials.Filters.Add(textSeg.Bubble);

                    if (textSeg.Effect != null)
                        Materials.Filters.Add(textSeg.Effect);

                    Materials.Texts.Add(textSeg.ExportMaterial());
                    break;

                default:
                    throw new InvalidOperationException($"Unsupported segment type: {segmentType.Name}");
            }

            return this;
        }

        public ScriptFile AddEffect(EffectMeta effect, Timerange tRange, string? trackName = null, List<float?>? parameters = null)
        {
            var target = GetTrack(typeof(EffectSegment), trackName) as Track<EffectSegment>;
            if (target == null)
                throw new InvalidCastException("目标轨道不是 EffectSegment 类型的轨道");

            var segment = new EffectSegment(effect, tRange, parameters);
            target.AddSegment(segment);
            Duration = Math.Max(Duration, tRange.Start + tRange.Duration);

            if (!Materials.VideoEffects.Contains(segment.EffectInstance))
            {
                Materials.VideoEffects.Add(segment.EffectInstance);
            }

            return this;
        }

        public ScriptFile AddFilter(EffectMeta filterMeta, Timerange tRange, string? trackName = null, float intensity = 100.0f)
        {
            var target = GetTrack(typeof(FilterSegment), trackName) as Track<FilterSegment>;
            if (target == null)
                throw new InvalidCastException("目标轨道不是 FilterSegment 类型的轨道");

            var segment = new FilterSegment(filterMeta, tRange, intensity / 100.0f);
            target.AddSegment(segment);
            Duration = Math.Max(Duration, tRange.End);

            Materials.Filters.Add(segment.Material);

            return this;
        }

        public ScriptFile ImportSrt(string srtPath, string trackName,
    object timeOffset = null,
    TextSegment styleReference = null,
    TextStyle textStyle = null,
    ClipSettings clipSettings = null)
        {
            if (styleReference == null && clipSettings == null)
                throw new ArgumentException("未提供样式参考时请提供 clipSettings 参数");

            int offset = TimeUtil.Tim(timeOffset ?? 0.0);
            if (!Tracks.ContainsKey(trackName))
            {
                AddTrack(TrackType.FromName(trackName), trackName, relativeIndex: 999); // 默认添加在最上层
            }

            var lines = File.ReadAllLines(srtPath, Encoding.UTF8);
            int index = 0;
            string text = "";
            Timerange textRange = null;
            string readState = "index";

            void AddTextSegment(string content, Timerange range)
            {
                TextSegment segment;
                if (styleReference != null)
                {
                    segment = TextSegment.CreateFromTemplate(content, range, styleReference);
                    if (clipSettings != null)
                        segment.ClipSettings = clipSettings; // 假设你已实现 Clone 方法
                }
                else
                {
                    segment = new TextSegment(content, range, null, textStyle ?? new TextStyle(), clipSettings);
                }
                AddSegment(segment, trackName);
            }

            while (index < lines.Length)
            {
                var line = lines[index].Trim();
                if (readState == "index")
                {
                    if (line.Length == 0)
                    {
                        index++;
                        continue;
                    }
                    if (!int.TryParse(line, out _))
                        throw new FormatException($"第 {index + 1} 行应为字幕编号，但内容为: '{line}'");
                    index++;
                    readState = "timestamp";
                }
                else if (readState == "timestamp")
                {
                    var parts = line.Split(new[] { " --> " }, StringSplitOptions.None);
                    var start = TimeUtil.SrtTstamp(parts[0]) + offset;
                    var end = TimeUtil.SrtTstamp(parts[1]) + offset;
                    textRange = new Timerange(start, end - start);
                    index++;
                    readState = "content";
                }
                else if (readState == "content")
                {
                    if (line.Length == 0)
                    {
                        AddTextSegment(text.Trim(), textRange);
                        text = "";
                        readState = "index";
                    }
                    else
                    {
                        text += line + "\n";
                    }
                    index++;
                }
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                AddTextSegment(text.Trim(), textRange);
            }

            return this;
        }

        public EditableTrack GetImportedTrack(
    TrackTypeName trackType,
    string name = null,
    int? index = null)
        {
            // 筛选指定类型的导入轨道
            var tracksOfSameType = new List<EditableTrack>();
            foreach (var track in this.ImportedTracks)
            {
                if (track.TrackTypeName == trackType)
                {
                    if (track is EditableTrack editableTrack)
                    {
                        tracksOfSameType.Add(editableTrack);
                    }
                    else
                    {
                        throw new InvalidCastException("轨道不是 EditableTrack 类型");
                    }
                }
            }

            var ret = new List<EditableTrack>();
            for (int ind = 0; ind < tracksOfSameType.Count; ind++)
            {
                var track = tracksOfSameType[ind];
                if (name != null && track.Name != name) continue;
                if (index.HasValue && ind != index.Value) continue;
                ret.Add(track);
            }

            if (ret.Count == 0)
            {
                throw new Exception(
                    $"没有找到满足条件的轨道: track_type={trackType}, name={name}, index={index}");
            }
            if (ret.Count > 1)
            {
                throw new Exception(
                    $"找到多个满足条件的轨道: track_type={trackType}, name={name}, index={index}");
            }

            return ret[0];
        }


        public ScriptFile ImportTrack(
            ScriptFile sourceFile,
            EditableTrack track,
            object offset = null,
            string newName = null,
            int? relativeIndex = null)
        {
            // 深拷贝轨道
            var importedTrack = track; // 需要实现 DeepClone 方法
            if (relativeIndex.HasValue)
            {
                importedTrack.RenderIndex = track.RenderIndex + relativeIndex.Value;
            }
            if (newName != null)
            {
                importedTrack.Name = newName;
            }

            long offsetUs = TimeUtil.Tim(offset ?? 0);
            if (offsetUs != 0)
            {
                foreach (var seg in importedTrack.Segments)
                {
                    seg.TargetTimerange.Start = Math.Max(0, seg.TargetTimerange.Start + offsetUs);
                }
            }

            this.ImportedTracks.Add(importedTrack);

            // 收集需要复制的素材ID
            var materialIds = new HashSet<string>();
            if (track.RawData.TryGetValue("segments", out var segsObj) && segsObj is List<Dictionary<string, object>> segments)
            {
                foreach (var segment in segments)
                {
                    if (segment.TryGetValue("material_id", out var midObj) && midObj is string materialId)
                    {
                        materialIds.Add(materialId);
                    }
                    if (segment.TryGetValue("extra_material_refs", out var extraRefsObj) &&
                        extraRefsObj is List<string> extraRefs)
                    {
                        foreach (var refId in extraRefs)
                        {
                            materialIds.Add(refId);
                        }
                    }
                }
            }

            // 复制素材
            foreach (var kvp in sourceFile.ImportedMaterials)
            {
                string materialType = kvp.Key;
                var materialList = kvp.Value;
                foreach (var material in materialList)
                {
                    if (material.TryGetValue("id", out var idObj) && idObj is string id && materialIds.Contains(id))
                    {
                        if (!this.ImportedMaterials.ContainsKey(materialType))
                        {
                            this.ImportedMaterials[materialType] = new List<Dictionary<string, object>>();
                        }
                        this.ImportedMaterials[materialType].Add(material); // 需要实现 DeepClone
                        materialIds.Remove(id);
                    }
                }
            }

            if (materialIds.Count > 0)
            {
                throw new Exception($"未找到以下素材: {string.Join(", ", materialIds)}");
            }

            this.Duration = Math.Max(this.Duration, track.EndTime);

            return this;
        }

        public ScriptFile ReplaceMaterialByName(string materialName,
    object material, // VideoMaterial 或 AudioMaterial 的基类或接口
    bool replaceCrop = false)
        {
            bool videoMode = material is VideoMaterial;

            string materialTypeKey = videoMode ? "videos" : "audios";
            string nameKey = videoMode ? "material_name" : "name";

            if (!ImportedMaterials.TryGetValue(materialTypeKey, out var targetMaterialList))
            {
                throw new Exception($"没有找到名为 '{materialName}', 类型为 '{material.GetType()}' 的素材");
            }

            Dictionary<string, object> targetJsonObj = null;
            foreach (var mat in targetMaterialList)
            {
                if (mat.TryGetValue(nameKey, out var nameObj) && nameObj is string name && name == materialName)
                {
                    if (targetJsonObj != null)
                    {
                        throw new Exception(
                            $"找到多个名为 '{materialName}', 类型为 '{material.GetType()}' 的素材");
                    }
                    targetJsonObj = mat;
                }
            }

            if (targetJsonObj == null)
            {
                throw new Exception(
                    $"没有找到名为 '{materialName}', 类型为 '{material.GetType()}' 的素材");
            }

            // 更新素材信息
            // 注意：需要 VideoMaterial 和 AudioMaterial 提供对应属性
            if (videoMode)
            {
                var videoMat = (VideoMaterial)material;
                targetJsonObj[nameKey] = videoMat.MaterialName;
                targetJsonObj["path"] = videoMat.Path;
                targetJsonObj["duration"] = videoMat.Duration;
                targetJsonObj["width"] = videoMat.Width;
                targetJsonObj["height"] = videoMat.Height;
                targetJsonObj["material_type"] = videoMat.MaterialType;
                if (replaceCrop)
                {
                    targetJsonObj["crop"] = videoMat.CropSettings.ExportJson();
                }
            }
            else
            {
                var audioMat = (AudioMaterial)material;
                targetJsonObj[nameKey] = audioMat.MaterialName;
                targetJsonObj["path"] = audioMat.Path;
                targetJsonObj["duration"] = audioMat.Duration;
            }

            return this;
        }


        public ScriptFile ReplaceMaterialBySegment(
            EditableTrack track,
            int segmentIndex,
            object material, // VideoMaterial or AudioMaterial
            Timerange sourceTimerange = null,
            ShrinkMode handleShrink = ShrinkMode.CutTail,
            IEnumerable<ExtendMode> handleExtend = null)
        {
            if (!(track is ImportedMediaTrack importedTrack))
            {
                throw new Exception($"指定的轨道(类型为 {track.TrackTypeName})不支持素材替换");
            }

            if (segmentIndex < 0 || segmentIndex >= importedTrack.Segments.Count)
            {
                throw new IndexOutOfRangeException($"片段下标 {segmentIndex} 超出 [0, {importedTrack.Segments.Count}) 的范围");
            }

            if (!importedTrack.CheckMaterialType(material))
            {
                throw new Exception($"指定的素材类型 {material.GetType()} 不匹配轨道类型 {track.TrackTypeName}");
            }

            var seg = importedTrack.Segments[segmentIndex];

            if (handleExtend == null)
            {
                handleExtend = new[] { ExtendMode.CutMaterialTail };
            }

            if (sourceTimerange == null)
            {
                if (material is VideoMaterial videoMat && videoMat.MaterialType == "photo")
                {
                    sourceTimerange = new Timerange(0, seg.Duration);
                }
                else if (material is VideoMaterial videoMaterial)
                {
                    sourceTimerange = new Timerange(0, videoMaterial.Duration);
                }
                else if (material is AudioMaterial audioMaterial)
                {
                    sourceTimerange = new Timerange(0, audioMaterial.Duration);
                }
                else
                {
                    throw new ArgumentException("Unsupported material type");
                }
            }

            // 调用轨道的处理方法（假设已实现）
            importedTrack.ProcessTimerange(segmentIndex, sourceTimerange, handleShrink, handleExtend.ToList());

            // 替换素材ID
            importedTrack.Segments[segmentIndex].MaterialId = material is VideoMaterial vMat ? vMat.MaterialId :
                                                              material is AudioMaterial aMat ? aMat.MaterialId :
                                                              throw new ArgumentException("Unsupported material type");

            // 添加素材到 ScriptFile 的素材集合（假设已有 AddMaterial 方法）
            this.AddMaterial(material);

            // TODO: 更新总时长 (this.Duration = Math.Max(this.Duration, track.EndTime);)

            return this;
        }

        public ScriptFile ReplaceText(EditableTrack track, int segmentIndex, object text, bool recalcStyle = true)
        {
            if (!(track is ImportedTextTrack importedTextTrack))
            {
                throw new Exception($"指定的轨道(类型为 {track.TrackTypeName})不支持文本内容替换");
            }
            if (segmentIndex < 0 || segmentIndex >= importedTextTrack.Segments.Count)
            {
                throw new IndexOutOfRangeException($"片段下标 {segmentIndex} 超出 [0, {importedTextTrack.Segments.Count}) 的范围");
            }

            string materialId = importedTextTrack.Segments[segmentIndex].MaterialId;
            bool replaced = false;

            // 辅助函数：重新计算样式区间
            List<JObject> RecalcStyleRange(int oldLen, int newLen, List<JObject> styles)
            {
                var newStyles = new List<JObject>();
                foreach (var style in styles)
                {
                    var range = style["range"]?.ToObject<List<int>>();
                    if (range == null || range.Count != 2) continue;

                    int start = (int)Math.Ceiling((double)range[0] / oldLen * newLen);
                    int end = (int)Math.Ceiling((double)range[1] / oldLen * newLen);
                    style["range"] = new JArray(start, end);
                    if (start != end)
                    {
                        newStyles.Add(style);
                    }
                }
                return newStyles;
            }

            // 替换普通文本素材
            if (ImportedMaterials.TryGetValue("texts", out var textMaterials))
            {
                foreach (var mat in textMaterials)
                {
                    if (!mat.TryGetValue("id", out var idObj) || !(idObj is string id) || id != materialId)
                        continue;

                    // text 可以是 string 或 List<string>
                    List<string> textList;
                    if (text is string s)
                        textList = new List<string> { s };
                    else if (text is List<string> list)
                        textList = list;
                    else
                        throw new ArgumentException("text 参数类型错误，必须是 string 或 List<string>");

                    if (textList.Count != 1)
                    {
                        throw new ArgumentException($"正常文本片段只能有一个文字内容, 但替换内容是 {string.Join(", ", textList)}");
                    }

                    string newText = textList[0];

                    // mat["content"] 是 json 字符串，需要反序列化后修改
                    if (mat.TryGetValue("content", out var contentObj) && contentObj is string contentStr)
                    {
                        var content = JObject.Parse(contentStr);
                        var oldText = content["text"]?.ToString() ?? "";
                        if (recalcStyle)
                        {
                            var styles = content["styles"]?.ToObject<List<JObject>>() ?? new List<JObject>();
                            content["styles"] = JArray.FromObject(RecalcStyleRange(oldText.Length, newText.Length, styles));
                        }
                        content["text"] = newText;
                        mat["content"] = content.ToString(Formatting.None);
                    }
                    else
                    {
                        mat["content"] = newText;
                    }

                    replaced = true;
                    break;
                }
            }

            if (replaced)
                return this;

            // 替换文本模板素材
            if (ImportedMaterials.TryGetValue("text_templates", out var textTemplates))
            {
                foreach (var template in textTemplates)
                {
                    if (!template.TryGetValue("id", out var idObj) || !(idObj is string id) || id != materialId)
                        continue;

                    if (!template.TryGetValue("text_info_resources", out var resourcesObj) ||
                        !(resourcesObj is JArray resources))
                    {
                        throw new Exception("文本模板素材格式异常");
                    }

                    List<string> textList;
                    if (text is string s)
                        textList = new List<string> { s };
                    else if (text is List<string> list)
                        textList = list;
                    else
                        throw new ArgumentException("text 参数类型错误，必须是 string 或 List<string>");

                    if (textList.Count > resources.Count)
                    {
                        throw new ArgumentException($"文字模板'{template.GetValueOrDefault("name")}'只有{resources.Count}段文本, 但提供了{textList.Count}段替换内容");
                    }

                    for (int i = 0; i < textList.Count; i++)
                    {
                        var resource = resources[i];
                        string subMaterialId = resource["text_material_id"]?.ToString();
                        if (string.IsNullOrEmpty(subMaterialId))
                            continue;

                        foreach (var mat in ImportedMaterials["texts"])
                        {
                            if (!mat.TryGetValue("id", out var midObj) || !(midObj is string mid) || mid != subMaterialId)
                                continue;

                            string newText = textList[i];
                            if (mat.TryGetValue("content", out var contentObj2) && contentObj2 is string contentStr2)
                            {
                                // 如果内容是 JSON 字符串，则反序列化处理
                                try
                                {
                                    var content = JObject.Parse(contentStr2);
                                    var oldText = content["text"]?.ToString() ?? "";
                                    if (recalcStyle)
                                    {
                                        var styles = content["styles"]?.ToObject<List<JObject>>() ?? new List<JObject>();
                                        content["styles"] = JArray.FromObject(RecalcStyleRange(oldText.Length, newText.Length, styles));
                                    }
                                    content["text"] = newText;
                                    mat["content"] = content.ToString(Formatting.None);
                                }
                                catch (JsonReaderException)
                                {
                                    // 内容不是 JSON 字符串，直接替换为新文本
                                    mat["content"] = newText;
                                }
                            }
                            else
                            {
                                mat["content"] = newText;
                            }

                            break; // 找到对应素材替换后跳出
                        }
                    }
                    replaced = true;
                    break;
                }
            }

            if (!replaced)
                throw new Exception($"未找到指定片段的素材 {materialId}");

            return this;
        }

        public string Dumps()
        {
            // 设置基本属性
            Content["fps"] = Fps;
            Content["duration"] = Duration;
            Content["canvas_config"] = JObject.FromObject( new Dictionary<string, object>
        {
            { "width", Width },
            { "height", Height },
            { "ratio", "original" }
        });
            Content["materials"] = JObject.FromObject(Materials.ExportJson());

            //// 合并导入的素材
            //var materialsDict = Materials.ExportJson() as Dictionary<string, object>;
            //foreach (var kvp in ImportedMaterials)
            //{
            //    if (!materialsDict.ContainsKey(kvp.Key))
            //    {
            //        materialsDict[kvp.Key] = kvp.Value;
            //    }
            //    else
            //    {
            //        var list = materialsDict[kvp.Key] as List<object>;
            //        list.AddRange(kvp.Value);
            //    }
            //}

            // 对轨道排序并导出
            var trackList = new List<BaseTrack>(Tracks.Values);
            trackList.AddRange(ImportedTracks);
            trackList.Sort((a, b) => a.RenderIndex.CompareTo(b.RenderIndex));
            var tracksJson = new List<JObject>();
            foreach (var track in trackList)
            {
                tracksJson.Add(JObject.FromObject(track.ExportJson()));
            }
            Content["tracks"] = JArray.FromObject( tracksJson);

            //// 导出为JSON字符串
            //var jsonOptions = new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            //};
            return JsonConvert.SerializeObject(Content);
        }
    }
}
