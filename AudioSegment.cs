using JyDraft.meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static  JyDraft.TimeUtil;

namespace JyDraft
{
    public class AudioFade
    {
        public string FadeId { get; }
        public int InDuration { get; }
        public int OutDuration { get; }

        public AudioFade(int inDuration, int outDuration)
        {
            FadeId = Guid.NewGuid().ToString();
            InDuration = inDuration;
            OutDuration = outDuration;
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
        {
            { "id", FadeId },
            { "fade_in_duration", InDuration },
            { "fade_out_duration", OutDuration },
            { "fade_type", 0 },
            { "type", "audio_fade" }
        };
        }
    }

    public class AudioEffect
    {
        public string Name { get; }
        public string EffectId { get; }
        public string ResourceId { get; }
        public string CategoryId { get; }
        public string CategoryName { get; }
        public List<EffectParamInstance> AudioAdjustParams { get; }

        public AudioEffect(EffectMeta effectMeta, List<float?> parameters = null)
        {
            // effectMeta 类型需根据实际情况实现，如 AudioSceneEffectType, ToneEffectType, SpeechToSongType
            var category = AudioEffectCategoryResolver.GetCategory(effectMeta);
            switch (category)
            {
                case AudioEffectCategory.Tone:
                    CategoryId = "tone";
                    CategoryName = "音色";
                    Name = effectMeta.Name;
                    ResourceId = effectMeta.ResourceId;
                    AudioAdjustParams = effectMeta.ParseParams(parameters);
                    break;

                case AudioEffectCategory.Audio:
                    CategoryId = "sound_effect";
                    CategoryName = "场景音";
                    Name = effectMeta.Name;
                    ResourceId = effectMeta.ResourceId;
                    AudioAdjustParams = effectMeta.ParseParams(parameters);
                    break;

                case AudioEffectCategory.Song:
                    CategoryId = "speech_to_song";
                    CategoryName = "声音成曲";
                    Name = effectMeta.Name;
                    ResourceId = effectMeta.ResourceId;
                    AudioAdjustParams = effectMeta.ParseParams(parameters);
                    break;

                default:
                    throw new InvalidOperationException("不支持的元数据类型。");
            }

            EffectId = Guid.NewGuid().ToString();
        }

        public Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
        {
            { "audio_adjust_params", AudioAdjustParams.Select(p => p.ExportJson()).ToList() },
            { "category_id", CategoryId },
            { "category_name", CategoryName },
            { "id", EffectId },
            { "is_ugc", false },
            { "name", Name },
            { "production_path", "" },
            { "resource_id", ResourceId },
            { "speaker_id", "" },
            { "sub_type", 1 },
            { "time_range", new Dictionary<string, int> { {"duration", 0}, {"start", 0} } },
            { "type", "audio_effect" }
        };
        }
    }

    public class AudioSegment : MediaSegment
    {
        public AudioMaterial MaterialInstance { get; }
        public AudioFade Fade { get; private set; }
        public List<AudioEffect> Effects { get; }
        // public List<string> ExtraMaterialRefs { get; } // 你可以在基类实现

        public AudioSegment(AudioMaterial material, Timerange targetTimerange, Timerange sourceTimerange = null, float? speed = null, float volume = 1.0f)
            : base(material.MaterialId, null, null, 1.0f, volume)
        {
            // 速度、时间区间的推导逻辑
            if (sourceTimerange != null && speed.HasValue)
            {
                targetTimerange = new Timerange(targetTimerange.Start, (int)Math.Round(sourceTimerange.Duration / speed.Value));
            }
            else if (sourceTimerange != null)
            {
                speed = sourceTimerange.Duration / (float)targetTimerange.Duration;
            }
            else
            {
                speed = speed ?? 1.0f;
                sourceTimerange = new Timerange(0, (int)Math.Round(targetTimerange.Duration * speed.Value));
            }

            if (sourceTimerange.End > material.Duration)
                throw new ArgumentException($"截取的素材时间范围 {sourceTimerange} 超出了素材时长({material.Duration})");

            // 初始化父类
            base.SourceTimerange = sourceTimerange;
            base.TargetTimerange = targetTimerange;
            base.Speed.Value = speed.Value;

            MaterialInstance = material; // 假设实现了 Clone
            Effects = new List<AudioEffect>();
        }

        public AudioSegment AddEffect(EffectMeta effectType, List<float?> parameters = null)
        {
            // effectType 类型需根据实际情况实现
            var effectInst = new AudioEffect(effectType, parameters);
            if (Effects.Any(e => e.CategoryId == effectInst.CategoryId))
                throw new ArgumentException($"当前音频片段已经有此类型 ({effectInst.CategoryName}) 的音效了");
            Effects.Add(effectInst);
            ExtraMaterialRefs.Add(effectInst.EffectId);
            return this;
        }

        public AudioSegment AddFade(object inDuration, object outDuration)
        {
            if (Fade != null)
                throw new ArgumentException("当前片段已存在淡入淡出效果");

            int ParseDuration(object duration)
            {
                if (duration is int i) return i;
                if (duration is string s) return TimeUtil.Tim(s); // 假设有 TimUtil.Tim(string) 方法
                throw new ArgumentException("无效的时长参数");
            }

            Fade = new AudioFade(ParseDuration(inDuration), ParseDuration(outDuration));
            ExtraMaterialRefs.Add(Fade.FadeId);
            return this;
        }

        public AudioSegment AddKeyframe(int timeOffset, float volume)
        {
            var property = KeyframeProperty.Volume;
            var kfList = CommonKeyframes.FirstOrDefault(k => k.Property == property);
            if (kfList != null)
            {
                kfList.AddKeyframe(timeOffset, volume);
                return this;
            }
            kfList = new KeyframeList(property);
            kfList.AddKeyframe(timeOffset, volume);
            CommonKeyframes.Add(kfList);
            return this;
        }

        public override Dictionary<string, object> ExportJson()
        {
            var jsonDict = base.ExportJson();
            jsonDict["clip"] = null;
            jsonDict["hdr_settings"] = null;
            return jsonDict;
        }
    }
}
