using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace JyDraft
{
    public static class TimeUtil
    {
        public const long SEC = 1000000; // 一秒 = 1e6 微秒

        // 将输入的字符串转换为微秒, 支持 "1h52m3s" 或 "0.15s" 这样的格式
        public static int Tim(object inp)
        {
            if (inp is int || inp is long || inp is float || inp is double)
            {
                return Convert.ToInt32(Math.Round(Convert.ToDouble(inp)));
            }

            string input = inp.ToString().Trim().ToLower();
            int sign = 1;
            if (input.StartsWith("-"))
            {
                sign = -1;
                input = input.Substring(1);
            }

            int lastIndex = 0;
            double totalTime = 0;
            foreach (var (unit, factor) in new[] {
                ("h", 3600 * SEC),
                ("m", 60 * SEC),
                ("s", SEC),
            })
            {
                int unitIndex = input.IndexOf(unit);
                if (unitIndex == -1) continue;
                string numberStr = input.Substring(lastIndex, unitIndex - lastIndex);
                totalTime += double.Parse(numberStr, CultureInfo.InvariantCulture) * factor;
                lastIndex = unitIndex + 1;
            }

            return (int)Math.Round(totalTime) * sign;
        }

        // Timerange类
        public class Timerange : IEquatable<Timerange>
        {
            // 起始时间, 单位为微秒
            public long Start { get; set; }
            // 持续长度, 单位为微秒
            public long Duration { get; set; }

            public Timerange(long start, long duration)
            {
                Start = start;
                Duration = duration;
            }

            public static Timerange ImportJson(string jsonObj)
            {
                var match = Regex.Match(jsonObj, @"^\[start=(\d+),\s*end=(\d+)\]$");
                if (!match.Success)
                    throw new FormatException("Invalid format");

                return new Timerange(int.Parse(match.Groups[1].Value),int.Parse(match.Groups[2].Value)- int.Parse(match.Groups[1].Value));

                //return new Timerange(int.Parse(jsonObj["start"]), int.Parse(jsonObj["duration"]));
            }

            public long End => Start + Duration;

            public bool Equals(Timerange other)
            {
                if (other == null) return false;
                return Start == other.Start && Duration == other.Duration;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Timerange);
            }

            public override int GetHashCode()
            {
                return (Start, Duration).GetHashCode();
            }

            // 判断两个时间范围是否有重叠
            public bool Overlaps(Timerange other)
            {
                return !(End <= other.Start || other.End <= Start);
            }

            public override string ToString()
            {
                return $"[start={Start}, end={End}]";
            }

            public string Repr()
            {
                return $"Timerange(start={Start}, duration={Duration})";
            }

            public Dictionary<string, long> ExportJson()
            {
                return new Dictionary<string, long>
                {
                    {"start", Start },
                    {"duration", Duration }
                };
            }
        }

        // Timerange的简便构造函数, 接受字符串或微秒数作为参数
        public static Timerange Trange(object start, object duration)
        {
            return new Timerange(Tim(start), Tim(duration));
        }

        // 解析SRT中的时间戳字符串, 返回微秒数
        public static long SrtTstamp(string srtTstamp)
        {
            var parts = srtTstamp.Split(',');
            var secParts = parts[0].Split(':');
            // secParts[0]: hours, secParts[1]: minutes, secParts[2]: seconds, parts[1]: milliseconds
            long totalTime = 0;
            long[] factors = { 3600 * SEC, 60 * SEC, SEC, 1000 };
            for (int i = 0; i < 3; i++)
            {
                totalTime += long.Parse(secParts[i]) * factors[i];
            }
            totalTime += long.Parse(parts[1]) * factors[3];
            return totalTime;
        }
    }
}
