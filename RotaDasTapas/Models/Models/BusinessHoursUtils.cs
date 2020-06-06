using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using RotaDasTapas.Constants;

namespace RotaDasTapas.Models.Models
{
    public class BusinessHoursUtils
    {
        private readonly string _locale;
        private readonly IDateTimeWrapper _dateTime;
        private readonly List<ScheduleDay> _scheduleDays;

        private const string CompressedPattern =
            @"(?<openHour>[0-9]{2}):(?<openMinutes>[0-9]{2}),(?<closeHour>[0-9]{2}):(?<closeMinutes>[0-9]{2});(?<minDay>[1-7]),(?<maxDay>[1-7])";

        public BusinessHoursUtils(string businessHours, IDateTimeWrapper dateTime, string locale = "")
        {
            _locale = locale.Replace("_", "-");
            _dateTime = dateTime;
            _scheduleDays = GetTimeFromCompressed(businessHours);
        }

        public string GetStatus()
        {
            var currWeekDay = (int) _dateTime.Now.DayOfWeek;
            var scheduleDay =
                _scheduleDays.Find(opt => opt.WeekDay.Min <= currWeekDay && opt.WeekDay.Max >= currWeekDay);

            if (scheduleDay == null)
            {
                return BusinessHoursConstants.Closed;
            }

            var isClosingSoon = scheduleDay.Hours.Max - _dateTime.Now.TimeOfDay > new TimeSpan(0,30,0);
            return isClosingSoon ? BusinessHoursConstants.Open : BusinessHoursConstants.ClosingSoon;
        }

        public string GetCurrentSchedule()
        {
            var currWeekDay = (int) _dateTime.Now.DayOfWeek;
            var scheduleDay =
                _scheduleDays.Find(opt => opt.WeekDay.Min <= currWeekDay && opt.WeekDay.Max >= currWeekDay);

            if (scheduleDay == null)
            {
                return string.Empty;
            }

            return string.Join("-", GetTimespanToString(scheduleDay.Hours.Min),
                GetTimespanToString(scheduleDay.Hours.Max));
        }

        private List<ScheduleDay> GetTimeFromCompressed(string compressed)
        {
            var weekDaysList = new List<ScheduleDay>();
            var scheduleByDays = compressed.Split('|');

            foreach (var schedule in scheduleByDays)
            {
                weekDaysList.Add(GetTimeFromPatternCompressed(schedule));
            }

            return weekDaysList;
        }

        private ScheduleDay GetTimeFromPatternCompressed(string compressed)
        {
            var regex = new Regex(CompressedPattern);
            var match = regex.Match(compressed);
            var scheduleDay = new ScheduleDay();

            if (match.Success)
            {
                scheduleDay.Hours = new Hours()
                {
                    Min = new TimeSpan(int.Parse(match.Groups["openHour"].Value),
                        int.Parse(match.Groups["openMinutes"].Value), 0),
                    Max = new TimeSpan(int.Parse(match.Groups["closeHour"].Value),
                        int.Parse(match.Groups["closeMinutes"].Value), 0),
                };
                scheduleDay.WeekDay = new WeekDay()
                {
                    Min = int.Parse(match.Groups["minDay"].Value),
                    Max = int.Parse(match.Groups["maxDay"].Value)
                };
            }

            return scheduleDay;
        }

        private string GetTimespanToString(TimeSpan ts)
        {
            var ci = CultureInfo.CreateSpecificCulture(_locale);
            var dt = new DateTime(ts.Ticks);
            return dt.ToString(ci.DateTimeFormat.ShortTimePattern);
        }
    }
}