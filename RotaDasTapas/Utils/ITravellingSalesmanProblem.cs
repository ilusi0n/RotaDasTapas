using System.Collections.Generic;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public interface ITravellingSalesmanProblem
    {
        void Init(TspModel tspModel);
        IEnumerable<Vertice> Solve(out double cost);
    }
}