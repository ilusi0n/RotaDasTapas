using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Gateway
{
    public class TapasGateway : ITapasGateway
    {
        private readonly IEnumerable<TapaDto> _listTapas;

        public TapasGateway()
        {
            //_listTapas = TapasUtils.Init();
            _listTapas = TapasUtils.InitMock();
        }

        public IEnumerable<TapaDto> GetAllTapas()
        {
            return _listTapas;
        }

        public TapaDto GetTapaByName(string name)
        {
            return _listTapas.FirstOrDefault(tapa => tapa.Name.Equals(name));
        }

        public IEnumerable<TapaDto> GetTapasByCity(string city)
        {
            return _listTapas.Where(tapa => tapa.City.Equals(city));
        }

        public IEnumerable<TapaDto> GetTapasRoute(string city)
        {
            var list = new List<string>()
            {
                "Lisboa_1", "Lisboa_2", "Lisboa_3","Lisboa_4"
            };
            var journeyUtils = new JourneyUtils(list, city);
            var vertices = journeyUtils.GetVertices();
            var adjacentmatrix = journeyUtils.GetMatrix();
            var problem = new TravellingSalesmanProblem(vertices, adjacentmatrix);
            double cost;
            var hue = problem.Solve(out cost);
            return new List<TapaDto>();
        }
    }
}