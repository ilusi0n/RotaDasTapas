using System;

namespace RotaDasTapas.Utils
{
    public interface IBusinessUtils
    {
        void Init(string businessHours, DateTime dateTime);
        string GetStatus();
        string GetCurrentSchedule();
    }
}