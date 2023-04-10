using System;
using System.Collections.Generic;

namespace MozartUI.Gantt.Util
{
    public class DateTimeRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DateTimeRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public bool IsOverlaps(DateTimeRange other, bool containsEqual = false)
        {
            if (containsEqual)
            {
                return From <= other.To && other.From <= To;
            }
            else
            {
                return From < other.To && other.From < To;
            }
        }

        public double Diff(string unit)
        {
            var span = To - From;

            switch (unit)
            {
                case "ms":
                case "millisecond":
                    return span.TotalMilliseconds;
                case "s":
                case "second":
                    return span.TotalSeconds;
                case "m":
                case "minute":
                    return span.TotalMinutes;
                case "h":
                case "hour":
                    return span.TotalHours;
                case "d":
                case "days":
                    return span.TotalDays;
                default:
                    return span.Ticks;
            }
        }

        public DateTimeRange Intersect(DateTimeRange other)
        {
            var start = From;
            var end = To;
            var otherStart = other.From;
            var otherEnd = other.To;
            var isZeroLength = start == end;
            var isOtherZeroLength = otherStart == otherEnd;

            // Zero-length ranges
            if (isZeroLength)
            {
                var point = start;

                if (point == otherStart || point == otherEnd)
                {
                    return null;
                }
                else if (point > otherStart && point < otherEnd)
                {
                    // return this.Copy();
                    return new DateTimeRange(From, To);
                }
            }
            else if (isOtherZeroLength)
            {
                var point = otherStart;

                if (point == start || point == end)
                {
                    return null;
                }
                else if (point > start && point < end)
                {
                    return new DateTimeRange(point, point);
                }
            }

            // Non zero-length ranges
            if (start <= otherStart && otherStart < end && end < otherEnd)
            {
                return new DateTimeRange(otherStart, end);
            }
            else if (otherStart < start && start < otherEnd && otherEnd <= end)
            {
                return new DateTimeRange(start, otherEnd);
            }
            else if (otherStart < start && start <= end && end < otherEnd)
            {
                // return this.Copy();
                return new DateTimeRange(From, To);
            }
            else if (start <= otherStart && otherStart <= otherEnd && otherEnd <= end)
            {
                return new DateTimeRange(otherStart, otherEnd);
            }

            return null;
        }

        public IEnumerable<DateTimeRange> Subtract(DateTimeRange other)
        {
            var start = From;
            var end = To;
            var oStart = other.From;
            var oEnd = other.To;

            if (Intersect(other) == null)
            {
                return new List<DateTimeRange> { this };
            }
            else if (oStart <= start && start < end && end <= oEnd)
            {
                return new List<DateTimeRange>();
            }
            else if (oStart <= start && start < oEnd && oEnd < end)
            {
                return new List<DateTimeRange> { new DateTimeRange(oEnd, end) };
            }
            else if (start < oStart && oStart < end && end <= oEnd)
            {
                return new List<DateTimeRange> { new DateTimeRange(start, oStart) };
            }
            else if (start < oStart && oStart < oEnd && oEnd < end)
            {
                return new List<DateTimeRange>
                {
                    new DateTimeRange(start, oStart),
                    new DateTimeRange(oEnd, end),
                };
            }
            else if (start < oStart && oStart < end && oEnd < end)
            {
                return new List<DateTimeRange>
                {
                    new DateTimeRange(start, oStart),
                    new DateTimeRange(oStart, end),
                };
            }

            return new List<DateTimeRange>();
        }
    }
}
