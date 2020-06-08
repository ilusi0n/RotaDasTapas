using System.Collections.Generic;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public interface IJourneyUtils
    {
        void Init(IEnumerable<string> selectedTapas, string startTapaId,
            IEnumerable<TapaDto> tapasByCity);
        IEnumerable<Vertice> SolveProblem();
    }
}