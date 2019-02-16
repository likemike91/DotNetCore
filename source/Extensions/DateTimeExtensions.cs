using System;
using System.Linq;

namespace DotNetCore.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime NextDateTime(this DateTime dateTime, DayOfWeek[] days, TimeSpan[] times)
        {
            times = times.OrderBy(x => x.Hours).ToArray();

            var nextTimes = times.Where(x => x.Hours > dateTime.TimeOfDay.Hours).ToArray();

            return nextTimes.Length > 0 ? dateTime.Date + nextTimes[0] : dateTime.NextDateTime(days).Date + times[0];
        }

        public static DateTime NextDateTime(this DateTime dateTime, params DayOfWeek[] days)
        {
            return Enumerable.Range(1, 7).Cast<double>().Select(dateTime.AddDays).First(y => days.Contains(y.DayOfWeek));
        }

        public static DateTime SetTime(this DateTime dateTime, int hours, int minutes, int seconds)
        {
            if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
            {
                return dateTime;
            }

            return dateTime.Date + new TimeSpan(hours, minutes, seconds);
        }
    }
}
