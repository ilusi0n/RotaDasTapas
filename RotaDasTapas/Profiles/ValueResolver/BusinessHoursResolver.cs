using System;
using AutoMapper;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Profiles.ValueResolver
{
    public class BusinessHoursResolver : IValueResolver<TapaDto, Tapa, Schedule>
    {
        private readonly IBusinessUtils _businessUtils;
        public BusinessHoursResolver(IBusinessUtils businessUtils)
        {
            _businessUtils = businessUtils;
        }
        public Schedule Resolve(TapaDto source, Tapa destination, Schedule destMember,
            ResolutionContext context)
        {
            var localtime = DateTime.Parse((string) context.Items["localtime"]);
            _businessUtils.Init(source.Schedule, localtime);
            return new Schedule
            {
                Status = _businessUtils.GetStatus(),
                Hours = _businessUtils.GetCurrentSchedule()
            };
        }
    }
}