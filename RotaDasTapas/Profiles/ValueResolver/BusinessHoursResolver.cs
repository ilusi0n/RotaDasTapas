using System;
using AutoMapper;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Profiles.ValueResolver
{
    public class BusinessHoursResolver : IValueResolver<TapaDto, Tapa, Schedule>
    {
        public Schedule Resolve(TapaDto source, Tapa destination, Schedule destMember,
            ResolutionContext context)
        {
            var localtime = DateTime.Parse((string) context.Items["localtime"]);
            var businessHours = new BusinessHoursUtils(source.Schedule, localtime);
            return new Schedule
            {
                Status = businessHours.GetStatus(),
                Hours = businessHours.GetCurrentSchedule(),
            };
        }
    }
}