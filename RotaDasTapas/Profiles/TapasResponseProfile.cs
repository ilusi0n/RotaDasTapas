using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Profiles.TypeConverter;

namespace RotaDasTapas.Profiles
{
    public class TapasResponseProfile : Profile
    {
        public TapasResponseProfile()
        {
            CreateMap<TapaDto, Tapa>()
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom<BusinessHoursResolver>());
            CreateMap<IEnumerable<TapaDto>, TapasResponse>()
                .ForMember(dest => dest.Tapas, opt => opt.MapFrom(src => src))
                .AfterMap((foo, dto) =>
                {
                    dto.Tapas = dto.Tapas.OrderBy(tapa => tapa.City).ThenBy(tapa => tapa.Name);
                });
            CreateMap<TapaDto, TapasResponse>().ConvertUsing<TapasResponseTypeConverter>();
        }
    }
}