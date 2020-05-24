using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Profiles.TypeConverter;

namespace RotaDasTapas.Profiles
{
    public class TapasResponseProfile : Profile
    {
        public TapasResponseProfile()
        {
            CreateMap<TapaDto, Tapa>();
            CreateMap<IEnumerable<TapaDto>, TapasResponse>()
                .ForMember(dest => dest.Tapas, opt => opt.MapFrom(src => src))
                .AfterMap((foo, dto) =>
                {
                    dto.Tapas = dto.Tapas.ToList().OrderBy(tapa => tapa.City).ThenBy(tapa => tapa.Name);
                });
            CreateMap<TapaDto, TapasResponse>().ConvertUsing<TapasResponseTypeConverter>();
        }
    }
}