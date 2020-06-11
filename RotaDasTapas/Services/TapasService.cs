using System.Linq;
using AutoMapper;
using RotaDasTapas.Constants;
using RotaDasTapas.Gateway;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Services
{
    public class TapasService : ITapasService
    {
        private readonly IJourneyUtils _journeyUtils;
        private readonly IMapper _mapper;
        private readonly ITapasGateway _tapasGateway;

        public TapasService(ITapasGateway tapasGateway, IMapper mapper, IJourneyUtils journeyUtils)
        {
            _tapasGateway = tapasGateway;
            _mapper = mapper;
            _journeyUtils = journeyUtils;
        }

        public TapasResponse GetAllTapas(TapasParameters tapasParameters)
        {
            var result = _tapasGateway.GetAllTapas();
            return _mapper.Map<TapasResponse>(result,
                opts => { opts.Items["localtime"] = tapasParameters.Localtime; });
        }

        public TapasResponse GetTapasRoute(JourneyParameters journeyParameters)
        {
            var result = _tapasGateway.GetTapasRoute(journeyParameters.City);
            var listSelectedTapas = journeyParameters.ListSelectedTapas.Split(Separators.Pipe);
            _journeyUtils.Init(listSelectedTapas, listSelectedTapas.First(), result);
            var pathToTake = _journeyUtils.SolveProblem().ToList();
            pathToTake.RemoveAt(pathToTake.Count - 1);
            return _mapper.Map<TapasResponse>(pathToTake,
                opts => { opts.Items["localtime"] = journeyParameters.Localtime; });
        }
    }
}