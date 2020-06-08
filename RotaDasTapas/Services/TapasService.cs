using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using RotaDasTapas.Gateway;
using RotaDasTapas.Models;
using RotaDasTapas.Utils;
using RotaDasTapas.Models.Response;

namespace RotaDasTapas.Services
{
    public class TapasService : ITapasService
    {
        private readonly ITapasGateway _tapasGateway;
        private readonly IMapper _mapper;

        public TapasService(ITapasGateway tapasGateway, IMapper mapper)
        {
            _tapasGateway = tapasGateway;
            _mapper = mapper;
        }

        public TapasResponse GetAllTapas()
        {
            var result = _tapasGateway.GetAllTapas();
            return _mapper.Map<TapasResponse>(result);
        }

        public TapasResponse GetTapaByName(string name)
        {
            var result = _tapasGateway.GetTapaByName(name);
            return _mapper.Map<TapasResponse>(result);
        }

        public TapasResponse GetTapaByCity(string city)
        {
            var result = _tapasGateway.GetTapasByCity(city);
            return _mapper.Map<TapasResponse>(result);
        }

        public TapasResponse GetTapasRoute(string city)
        {
            var result = _tapasGateway.GetTapasRoute(city);

            var listSelectedTapas = new List<string>()
            {
                "Lisboa_1", "Lisboa_2", "Lisboa_3", "Lisboa_4"
            };
            var journeyUtils = new JourneyUtils(listSelectedTapas, "Lisboa_4", result);
            var pathToTake = journeyUtils.SolveProblem();
            pathToTake.ToList().RemoveAt(pathToTake.Count()-1);

            return _mapper.Map<TapasResponse>(result);
        }
    }
}