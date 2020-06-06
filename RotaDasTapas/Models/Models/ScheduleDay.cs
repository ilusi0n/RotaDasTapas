using System;

namespace RotaDasTapas.Models.Models
{
    public class ScheduleDay
        {
            public Hours Hours { get; set; }
            public WeekDay WeekDay { get; set; }
            public ScheduleDay Next { get; set; }
            public bool IsOpen24Hours => Hours.Max - Hours.Min == Hours.Max || Hours.Duration == new TimeSpan(24, 0, 0);
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
            public TimeSpan Duration { get; set; }
        }
}