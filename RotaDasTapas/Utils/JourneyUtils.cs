using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public class JourneyUtils : IJourneyUtils
    {
        private readonly ITravellingSalesmanProblem _travellingSalesmanProblem;
        private IEnumerable<string> _selectedTapas;
        private IEnumerable<TapaDto> _tapasByCity;

        public JourneyUtils(ITravellingSalesmanProblem travellingSalesmanProblem)
        {
            _travellingSalesmanProblem = travellingSalesmanProblem;
        }

        public void Init(IEnumerable<string> selectedTapas, string startTapaId, IEnumerable<TapaDto> tapasByCity)
        {
            _selectedTapas = selectedTapas;
            _tapasByCity = tapasByCity;
            var startVertice = selectedTapas.ToList().IndexOf(startTapaId);
            var vertices = GetVertices();
            var adjacencyMatrix = BuildMatrix(vertices);
            var tspModel = new TspModel
            {
                StartVerticeId = startVertice,
                vertices = vertices,
                matrix = adjacencyMatrix
            };
            _travellingSalesmanProblem.Init(tspModel);
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
                list.Add(new Vertice
                {
                    Id = i,
                    TapaDto = _tapasByCity.First(el => el.Id.Equals(tapaId))
                });
                i++;
            }

            return list;
        }

        private Path[,] BuildMatrix(IEnumerable<Vertice> vertices)
        {
            var list = vertices.ToList();
            var adjacencyMatrix = new Path[list.Count, list.Count];
            for (var a = 0; a < list.Count; a++)
            {
                var tapa = list[a].TapaDto;
                tapa.Path = GetSelectedTapasPath(_selectedTapas, tapa);
                for (var b = 0; b < list[a].TapaDto.Path.Count(); b++)
                {
                    var path = list[a].TapaDto.Path.ToList()[b];
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