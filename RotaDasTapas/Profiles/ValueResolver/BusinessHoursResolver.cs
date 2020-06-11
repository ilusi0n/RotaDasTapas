using System;
using AutoMapper;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Profiles.ValueResolver
{
    public class BusinessHoursResolver : IValueResolver<TapaDto, Tapa, Schedule>
    {
        private readonly IBusinessHoursUtils _businessHoursUtils;

        public BusinessHoursResolver(IBusinessHoursUtils businessHoursUtils)
        {
            _businessHoursUtils = businessHoursUtils;
        }

        public Schedule Resolve(TapaDto source, Tapa destination, Schedule destMember,
            ResolutionContext context)
        {
            var localtime = DateTime.Parse((string) context.Items["localtime"]);
            _businessHoursUtils.Init(source.Schedule, localtime);
            return new Schedule
            {
                Status = _businessHoursUtils.GetStatus(),
                Hours = _businessHoursUtils.GetCurrentSchedule()
            };
        }
    }
}