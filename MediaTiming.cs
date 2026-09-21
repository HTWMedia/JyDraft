using static JyDraft.TimeUtil;

namespace JyDraft
{
    /// <summary>
    /// 片段「素材区间 / 轨道区间 / 速度」三者的推导规则。
    /// 原先 VideoSegment 与 AudioSegment 各写了一份，且细节不一致
    /// （视频用截断、音频用 Math.Round），这里统一为一处。
    /// </summary>
    /// <remarks>
    /// 三者只需任意两个即可确定第三个：
    /// <list type="bullet">
    /// <item>给了 source + speed → 反推 target 时长</item>
    /// <item>给了 source + target → 反推 speed</item>
    /// <item>只给 target → speed 取 1（或给定值），source 从 0 起算</item>
    /// </list>
    /// 统一后按截断取整（与原先 VideoSegment 的行为一致）。
    /// </remarks>
    internal readonly struct MediaTiming
    {
        public Timerange Source { get; }
        public Timerange Target { get; }
        public double Speed { get; }

        private MediaTiming(Timerange source, Timerange target, double speed)
        {
            Source = source;
            Target = target;
            Speed = speed;
        }

        public static MediaTiming Resolve(Timerange source, Timerange target, double? speed)
        {
            if (source != null && speed.HasValue)
            {
                var derived = new Timerange(target.Start, (int)(source.Duration / speed.Value));
                return new MediaTiming(source, derived, speed.Value);
            }

            if (source != null)
            {
                var derived = source.Duration / (double)target.Duration;
                return new MediaTiming(source, target, derived);
            }

            var resolvedSpeed = speed ?? 1.0;
            var derivedSource = new Timerange(0, (int)(target.Duration * resolvedSpeed));
            return new MediaTiming(derivedSource, target, resolvedSpeed);
        }
    }
}
