using System;

namespace RotaDasTapas.Utils
{
    public interface IBusinessHoursUtils
    {
        void Init(string businessHours, DateTime dateTime);
        string GetStatus();
        string GetCurrentSchedule();
    }
}