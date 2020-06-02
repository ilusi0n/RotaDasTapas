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

        public JourneyUtils(IEnumerable<string> selectedTapas, string startTapaId,
            IEnumerable<TapaDto> tapasByCity)
        {
            _tapasByCity = tapasByCity;
            var listTapasDto = GetListTapasDto(selectedTapas);
            var adjacencyMatrix = BuildMatrix(listTapasDto);
            var startVertice = listTapasDto.ToList().IndexOf(tapasByCity.First(el => el.Id.Equals(startTapaId)));
            var vertices = GetVertices(listTapasDto);
            _travellingSalesmanProblem = new TravellingSalesmanProblem(startVertice, vertices, adjacencyMatrix);
        }

        public IEnumerable<Vertice> SolveProblem()
        {
            return _travellingSalesmanProblem.Solve(out _);
        }

        private IEnumerable<Vertice> GetVertices(IEnumerable<TapaDto> listTapasDto)
        {
            var i = 0;
            var list = new List<Vertice>();
            foreach (var tapa in listTapasDto)
            {
                list.Add(new Vertice()
                {
                    Id = i,
                    TapaDto = tapa
                });
                i++;
            }
            return list;
        }

        private Path[,] BuildMatrix(IEnumerable<TapaDto> listTapasDto)
        {
            var tapasDto = listTapasDto.ToList();
            var adjacencyMatrix = new Path[tapasDto.Count(), tapasDto.Count()];
            for (var a = 0; a < tapasDto.Count(); a++)
            {
                for (var b = 0; b < tapasDto[a].Path.Count(); b++)
                {
                    var path = tapasDto[a].Path.ToList()[b];
                    adjacencyMatrix[a, b] = path;
                }
            }

            return adjacencyMatrix;
        }

        private IEnumerable<TapaDto> GetListTapasDto(IEnumerable<string> selectedTapas)
        {
            var list = new List<TapaDto>();
            foreach (var tapaId in selectedTapas)
            {
                var tapa = _tapasByCity.First(el => el.Id.Equals(tapaId));
                var path = GetSelectedTapasPath(selectedTapas, tapa);
                tapa.Path = path;
                list.Add(tapa);
            }

            return list.OrderBy(el => el.Id);
        }

        private IEnumerable<Path> GetSelectedTapasPath(IEnumerable<string> selectedTapas, TapaDto tapa)
        {
            return tapa.Path.Where(item => selectedTapas.Contains(item.TapaId)).OrderBy(el => el.TapaId).ToList();
        }
    }
}