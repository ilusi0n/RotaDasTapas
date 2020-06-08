using System.Linq;
using AutoMapper;
using RotaDasTapas.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Services
{
    public class TapasService : ITapasService
    {
        private readonly ITapasGateway _tapasGateway;
        private readonly IMapper _mapper;
        private readonly IJourneyUtils _journeyUtils;

        public TapasService(ITapasGateway tapasGateway, IMapper mapper, IJourneyUtils journeyUtils)
        {
            _tapasGateway = tapasGateway;
            _mapper = mapper;
            _journeyUtils = journeyUtils;
        }

        public TapasResponse GetAllTapas()
        {
            var result = _tapasGateway.GetAllTapas();
            return _mapper.Map<TapasResponse>(result);
        }

        public TapasResponse GetTapasRoute(string city, string list)
        {
            var result = _tapasGateway.GetTapasRoute(city);
            var listSelectedTapas = list.Split("|");
            _journeyUtils.Init(listSelectedTapas, listSelectedTapas.First(), result);
            var pathToTake = _journeyUtils.SolveProblem();
            pathToTake.ToList().RemoveAt(pathToTake.Count() - 1);

            return _mapper.Map<TapasResponse>(result);
        }
    }
}