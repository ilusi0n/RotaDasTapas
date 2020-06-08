using System.Collections.Generic;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public interface IJourneyUtils
    {
        IEnumerable<Vertice> SolveProblem();
    }
}