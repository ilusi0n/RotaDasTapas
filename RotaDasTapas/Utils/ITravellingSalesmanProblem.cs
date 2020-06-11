using System.Collections.Generic;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public interface ITravellingSalesmanProblem
    {
        void Init(int startVerticeIndex, IEnumerable<Vertice> vertices, Path[,] matrix);
        IEnumerable<Vertice> Solve(out double cost);
    }
}