using AutoMapper;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Profiles.TypeConverter
{
    public class VerticeTypeConverter : ITypeConverter<Vertice, Tapa>
    {
        private readonly IMapper _mapper;

        public VerticeTypeConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Tapa Convert(Vertice source, Tapa destination, ResolutionContext context)
        {
            return _mapper.Map<Tapa>(source.TapaDto,
                opts => { opts.Items["localtime"] = (string) context.Items["localtime"]; });
        }
    }
}