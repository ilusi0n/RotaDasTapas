using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Models;

namespace RotaDasTapas.Utils
{
    public class BusinessHoursUtils :  IBusinessUtils
    {
        private const string CompressedPattern =
            @"(?<openHour>[0-9]{2}):(?<openMinutes>[0-9]{2}),(?<closeHour>[0-9]{2}):(?<closeMinutes>[0-9]{2});(?<minDay>[0-6]),(?<maxDay>[0-6])";

        private  DateTime _dateTime;
        private  string _locale;
        private  TimeSpan _margin;
        private  List<ScheduleDay> _scheduleDays;

        public void Init(string businessHours, DateTime dateTime)
        {
            _locale = "pt-pt";
            _dateTime = dateTime;
            _scheduleDays = GetTimeFromCompressed(businessHours);
            _margin = new TimeSpan(0, 30, 0);
        }

        public string GetStatus()
        {
            if (!_scheduleDays.Any()) return string.Empty;

            var scheduleDay = GetCurrentScheduleDay();

            if (scheduleDay == null) return BusinessHoursConstants.ClosedToday;

            var isClosingSoon = IsPlaceClosingSoon(scheduleDay);
            var isOpeningSoon = IsPlaceOpeningSoon(scheduleDay);
            var isOpen = scheduleDay.Hours.Min < _dateTime.TimeOfDay &&
                         scheduleDay.Hours.Max > _dateTime.TimeOfDay;

            if (isClosingSoon) return BusinessHoursConstants.ClosingSoon;

            if (isOpeningSoon) return BusinessHoursConstants.OpeningSoon;

            return isOpen ? BusinessHoursConstants.Open : BusinessHoursConstants.Closed;
        }

        public string GetCurrentSchedule()
        {
            if (!_scheduleDays.Any()) return string.Empty;

            var scheduleDay = GetCurrentScheduleDay();

            if (scheduleDay == null) return string.Empty;

            return string.Join("-", GetTimespanToString(scheduleDay.Hours.Min),
                GetTimespanToString(scheduleDay.Hours.Max));
        }

        private bool IsPlaceOpeningSoon(ScheduleDay scheduleDay)
        {
            var timeDeference = scheduleDay.Hours.Min - _dateTime.TimeOfDay;
            return timeDeference <= _margin && timeDeference >= new TimeSpan(0, 0, 0);
        }

        private bool IsPlaceClosingSoon(ScheduleDay scheduleDay)
        {
            var timeDeference = scheduleDay.Hours.Max - _dateTime.TimeOfDay;
            return timeDeference <= _margin && timeDeference >= new TimeSpan(0, 0, 0);
        }

        private List<ScheduleDay> GetTimeFromCompressed(string compressed)
        {
            var weekDaysList = new List<ScheduleDay>();
            if (string.IsNullOrEmpty(compressed)) return weekDaysList;

            var scheduleByDays = compressed.Split('|');

            foreach (var schedule in scheduleByDays)
            {
                var weekday = GetTimeFromPatternCompressed(schedule);
                if (weekday == null) return new List<ScheduleDay>();

                weekDaysList.Add(weekday);
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
                scheduleDay.Hours = new Hours
                {
                    Min = new TimeSpan(int.Parse(match.Groups["openHour"].Value),
                        int.Parse(match.Groups["openMinutes"].Value), 0),
                    Max = new TimeSpan(int.Parse(match.Groups["closeHour"].Value),
                        int.Parse(match.Groups["closeMinutes"].Value), 0)
                };
                scheduleDay.WeekDay = new WeekDay
                {
                    Min = int.Parse(match.Groups["minDay"].Value),
                    Max = int.Parse(match.Groups["maxDay"].Value)
                };
                return scheduleDay;
            }

            return default;
        }

        private ScheduleDay GetCurrentScheduleDay()
        {
            var currWeekDay = (int) _dateTime.DayOfWeek;
            var scheduleDay =
                _scheduleDays.Find(opt => opt.WeekDay.Min <= currWeekDay && opt.WeekDay.Max >= currWeekDay);
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