using System.Collections.Generic;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.TSP;

namespace RotaDasTapas.Utils
{
    public interface IJourneyUtils
    {
        /// <summary>
        ///     Instantiate all the variables needed to calculate the optimal path
        /// </summary>
        /// <param name="selectedTapas">List of selected tapas for the optimal path</param>
        /// <param name="startTapaId">Starting point</param>
        /// <param name="tapasByCity">List of all tapas by wanted city</param>
        void Init(IEnumerable<string> selectedTapas, string startTapaId,
            IEnumerable<TapaDto> tapasByCity);

        IEnumerable<Vertice> SolveProblem();
    }
}