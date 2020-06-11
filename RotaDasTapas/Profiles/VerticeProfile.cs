using System.Collections.Generic;
using AutoMapper;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Models.TSP;
using RotaDasTapas.Profiles.TypeConverter;

namespace RotaDasTapas.Profiles
{
    public class VerticeProfile : Profile
    {
        public VerticeProfile()
        {
            CreateMap<Vertice, Tapa>().ConvertUsing<VerticeTypeConverter>();
            CreateMap<IEnumerable<Vertice>, TapasResponse>()
                .ForMember(dest => dest.Tapas, opt => opt.MapFrom(src => src));
        }
    }
}