using System.Collections.Generic;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Models.TSP
{
    public class TspModel
    {
        public int StartVerticeId { get; set; }
        public IEnumerable<Vertice> vertices { get; set; }
        public Path[,] matrix { get; set; }
    }
}