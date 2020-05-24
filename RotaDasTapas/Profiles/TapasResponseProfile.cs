using System.Collections;
using System.Collections.Generic;
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
                .ForMember(dest => dest.Tapas, opt => opt.MapFrom(src => src));
            CreateMap<TapaDto, TapasResponse>().ConvertUsing<TapasResponseTypeConverter>();
        }
    }
}