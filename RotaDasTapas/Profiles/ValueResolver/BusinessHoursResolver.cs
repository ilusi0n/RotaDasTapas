using AutoMapper;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Models;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Profiles.ValueResolver
{
    public class BusinessHoursResolver : IValueResolver<TapaDto, Tapa, Schedule>
    {
        private readonly IDateTimeWrapper _dateTimeWrapper;

        public BusinessHoursResolver(IDateTimeWrapper dateTimeWrapper)
        {
            _dateTimeWrapper = dateTimeWrapper;
        }

        public Schedule Resolve(TapaDto source, Tapa destination, Schedule destMember,
            ResolutionContext context)
        {
            var businessHours = new BusinessHoursUtils(source.Schedule, _dateTimeWrapper, "pt-pt");
            return new Schedule
            {
                Status = businessHours.GetStatus(),
                Hours = businessHours.GetCurrentSchedule(),
            };
        }
    }
}