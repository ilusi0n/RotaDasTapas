using System.Collections.Generic;
using AutoMapper;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Profiles.TypeConverter;
using RotaDasTapas.Profiles.ValueResolver;

namespace RotaDasTapas.Profiles
{
    public class TapasResponseProfile : Profile
    {
        public TapasResponseProfile()
        {
            CreateMap<TapaDto, Tapa>()
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom<BusinessHoursResolver>());
            CreateMap<IEnumerable<TapaDto>, TapasResponse>()
                .ForMember(dest => dest.Tapas, opt => opt.MapFrom(src => src));
            CreateMap<TapaDto, TapasResponse>().ConvertUsing<TapasResponseTypeConverter>();
        }
    }
}