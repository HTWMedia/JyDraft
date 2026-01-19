using JyDraft.meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JyDraft
{
    public class Animation
    {
        // 一个视频/文本动画效果
        public string Name { get; set; }
        public string EffectId { get; set; }
        public string AnimationType { get; set; }
        public string ResourceId { get; set; }

        public long Start { get; set; }
        public long Duration { get; set; }
        public bool IsVideoAnimation { get; set; }

        public Animation(AnimationMeta animationMeta, long start, long duration)
        {
            Name = animationMeta.Title;
            EffectId = animationMeta.EffectId;
            ResourceId = animationMeta.ResourceId;
            Start = start;
            Duration = duration;
        }

        public virtual Dictionary<string, object> ExportJson()
        {
            return new Dictionary<string, object>
            {
                { "anim_adjust_params", null },
                { "platform", "all" },
                { "panel", IsVideoAnimation ? "video" : "" },
                { "material_type", IsVideoAnimation ? "video" : "sticker" },

                { "name", Name },
                { "id", EffectId },
                { "type", AnimationType },
                { "resource_id", ResourceId },

                { "start", Start },
                { "duration", Duration }
                // 不导出path和request_id
            };
        }
    }

    public class VideoAnimation : Animation
    {
        public VideoAnimation(AnimationMeta meta, string animationType, long start, long duration)
            : base(meta, start, duration)
        {
            AnimationType = animationType; // "in", "out", "group"
            IsVideoAnimation = true;
        }
    }

    public class TextAnimation : Animation
    {
        public TextAnimation(AnimationMeta meta, string animationType, long start, long duration)
            : base(meta, start, duration)
        {
            AnimationType = animationType; // "in", "out", "loop"
            IsVideoAnimation = false;
        }
    }

    public class SegmentAnimations
    {
        // 附加于某素材上的一系列动画
        public string AnimationId { get; set; }
        public List<Animation> Animations { get; set; }

        public SegmentAnimations()
        {
            AnimationId = Guid.NewGuid().ToString();
            Animations = new List<Animation>();
        }

        public TimeUtil.Timerange GetAnimationTrange(string animationType)
        {
            // 获取指定类型的动画的时间范围
            foreach (var animation in Animations)
            {
                if (animation.AnimationType == animationType)
                    return new TimeUtil.Timerange(animation.Start, animation.Duration);
            }
            return null;
        }

        public void AddAnimation(Animation animation)
        {
            // 不允许添加超过一个同类型的动画（如两个入场动画）
            foreach (var ani in Animations)
            {
                if (ani.AnimationType == animation.AnimationType)
                    throw new Exception($"当前片段已存在类型为 '{animation.AnimationType}' 的动画");
            }

            if (animation is VideoAnimation)
            {
                // 不允许组合动画与出入场动画同时出现
                foreach (var ani in Animations)
                {
                    if (ani.AnimationType == "group")
                        throw new Exception("当前片段已存在组合动画, 此时不能添加其它动画");
                }
                if (animation.AnimationType == "group" && Animations.Count > 0)
                    throw new Exception("当前片段已存在动画时, 不能添加组合动画");
            }
            else if (animation is TextAnimation)
            {
                foreach (var ani in Animations)
                {
                    if (ani.AnimationType == "loop")
                        throw new Exception("当前片段已存在循环动画, 若希望同时使用循环动画和入出场动画, 请先添加出入场动画再添加循环动画");
                }
            }

            Animations.Add(animation);
        }

        public Dictionary<string, object> ExportJson()
        {
            var animList = new List<Dictionary<string, object>>();
            foreach (var animation in Animations)
            {
                animList.Add(animation.ExportJson());
            }

            return new Dictionary<string, object>
            {
                { "id", AnimationId },
                { "type", "sticker_animation" },
                { "multi_language_current", "none" },
                { "animations", animList }
            };
        }
    }
}
