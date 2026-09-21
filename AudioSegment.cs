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
    public class AudioFade : IDraftExportable
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

    public class AudioEffect : IDraftExportable
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

        private readonly List<AudioEffect> _effects;
        public IReadOnlyList<AudioEffect> Effects => _effects;
        // public List<string> ExtraMaterialRefs { get; } // 你可以在基类实现

        public AudioSegment(AudioMaterial material, Timerange targetTimerange, Timerange sourceTimerange = null,
                            float? speed = null, float volume = 1.0f)
            : this(material, MediaTiming.Resolve(sourceTimerange, targetTimerange, speed.HasValue ? (double?)speed.Value : null), volume)
        {
        }

        /// <summary>时间/速度推导完成后再交给基类，不再「先传 null 再回填」</summary>
        private AudioSegment(AudioMaterial material, MediaTiming timing, float volume)
            : base(material.MaterialId, timing.Source, timing.Target, timing.Speed, volume)
        {
            if (timing.Source.End > material.Duration)
                throw new ArgumentException($"截取的素材时间范围 {timing.Source} 超出了素材时长({material.Duration})");

            MaterialInstance = material;
            _effects = new List<AudioEffect>();
        }

        public AudioSegment AddEffect(EffectMeta effectType, List<float?> parameters = null)
        {
            // effectType 类型需根据实际情况实现
            var effectInst = new AudioEffect(effectType, parameters);
            if (_effects.Any(e => e.CategoryId == effectInst.CategoryId))
                throw new ArgumentException($"当前音频片段已经有此类型 ({effectInst.CategoryName}) 的音效了");
            _effects.Add(effectInst);
            AddExtraMaterialRef(effectInst.EffectId);
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
            AddExtraMaterialRef(Fade.FadeId);
            return this;
        }

        public AudioSegment AddKeyframe(int timeOffset, float volume)
        {
            AddKeyframeInternal(KeyframeProperty.Volume, timeOffset, volume);
            return this;
        }

        internal override void CollectMaterials(ScriptMaterial materials)
        {
            if (Fade != null && !materials.AudioFades.Contains(Fade))
                materials.AudioFades.Add(Fade);

            foreach (var effect in _effects)
                if (!materials.AudioEffects.Contains(effect))
                    materials.AudioEffects.Add(effect);

            materials.Speeds.Add(Speed);
            materials.AddMaterial(MaterialInstance);
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
