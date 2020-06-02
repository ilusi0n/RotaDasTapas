using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public class JourneyUtils
    {
        private readonly IEnumerable<TapaDto> _vertices;
        private readonly Path[,] _adjacencyMatrix;

        public JourneyUtils(IEnumerable<string> selectedTapas, string city)
        {
            _vertices = BuildVertices(selectedTapas,city);
            _adjacencyMatrix = BuildMatrix();
        }

        public Path[,] GetMatrix()
        {
            return _adjacencyMatrix;
        }

        public IEnumerable<Vertice> GetVertices()
        {
            var i = 0;
            var list = new List<Vertice>();
            foreach (var vertice in _vertices)
            {
                list.Add(new Vertice()
                {
                    Id = i,
                    TapaId = vertice.Id
                });
                i++;
            }
            return list;
        }

        private Path[,] BuildMatrix()
        {
            Path[,] adjacencyMatrix = new Path[_vertices.Count(), _vertices.Count()];
            for (int a = 0; a < _vertices.Count(); a++)
            {
                for (int b = 0; b < _vertices.ToList()[a].Path.Count(); b++)
                {
                    var path = _vertices.ToList()[a].Path.ToList()[b];
                    adjacencyMatrix[a,b] = path;
                }
            }

            return adjacencyMatrix;
        }

        private IEnumerable<TapaDto> BuildVertices(IEnumerable<string> selectedTapas, string city)
        {
            var listTapas = TapasUtils.InitMock().Where(tapa => tapa.City.Equals(city)).ToList();
            var list = new List<TapaDto>();
            foreach (var tapaId in selectedTapas)
            {
                var tapa = listTapas.First(el => el.Id.Equals(tapaId));
                var path = GetSelectedTapasPath(selectedTapas,tapa);
                tapa.Path = path;
                list.Add(tapa);
            }

            return list.OrderBy(el => el.Id);
        }

        private IEnumerable<Path> GetSelectedTapasPath(IEnumerable<string> selectedTapas,TapaDto tapa)
        {
            return tapa.Path.Where(item => selectedTapas.Contains(item.TapaId)).OrderBy(el => el.TapaId).ToList();
        }
    }
}