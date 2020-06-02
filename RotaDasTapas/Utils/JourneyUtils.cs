using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public class JourneyUtils
    {
        private readonly TravellingSalesmanProblem _travellingSalesmanProblem;
        private readonly IEnumerable<TapaDto> _tapasByCity;
        private readonly IEnumerable<string> _selectedTapas;

        public JourneyUtils(IEnumerable<string> selectedTapas, string startTapaId,
            IEnumerable<TapaDto> tapasByCity)
        {
            _selectedTapas = selectedTapas;
            _tapasByCity = tapasByCity;
            var adjacencyMatrix = BuildMatrix();
            var startVertice = tapasByCity.ToList().IndexOf(tapasByCity.First(el => el.Id.Equals(startTapaId)));
            var vertices = GetVertices();
            _travellingSalesmanProblem = new TravellingSalesmanProblem(startVertice, vertices, adjacencyMatrix);
        }

        public IEnumerable<Vertice> SolveProblem()
        {
            return _travellingSalesmanProblem.Solve(out _);
        }

        private IEnumerable<Vertice> GetVertices()
        {
            var i = 0;
            var list = new List<Vertice>();
            foreach (var tapaId in _selectedTapas)
            {
                list.Add(new Vertice()
                {
                    Id = i,
                    TapaDto = _tapasByCity.First(el => el.Id.Equals(tapaId))
                });
                i++;
            }
            return list;
        }

        private Path[,] BuildMatrix()
        {
            var tapasByCity = _tapasByCity.OrderBy(el => el.Id).ToList();
            var adjacencyMatrix = new Path[tapasByCity.Count(), tapasByCity.Count()];
            for (var a = 0; a < tapasByCity.Count(); a++)
            {
                var tapa = tapasByCity[a];
                tapa.Path = GetSelectedTapasPath(_selectedTapas, tapa);
                for (var b = 0; b < tapasByCity[a].Path.Count(); b++)
                {
                    var path = tapasByCity[a].Path.ToList()[b];
                    adjacencyMatrix[a, b] = path;
                }
            }

            return adjacencyMatrix;
        }

        private IEnumerable<Path> GetSelectedTapasPath(IEnumerable<string> selectedTapas, TapaDto tapa)
        {
            return tapa.Path.Where(item => selectedTapas.Contains(item.TapaId)).OrderBy(el => el.TapaId).ToList();
        }
    }
}