using System;

namespace RotaDasTapas.Models.Models
{
    public class ScheduleDay
    {
        public Hours Hours { get; set; }
        public WeekDay WeekDay { get; set; }
    }

    public class WeekDay
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Hours
    {
        public TimeSpan Min { get; set; }
        public TimeSpan Max { get; set; }
    }
}