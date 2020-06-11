using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;

namespace RotaDasTapas.Services
{
    public interface ITapasService
    {
        /// <summary>
        ///     Get all tapas from the server
        /// </summary>
        /// <param name="tapasParameters">Parameter request send by the user</param>
        /// <returns></returns>
        TapasResponse GetAllTapas(TapasParameters tapasParameters);

        /// <summary>
        ///     Calculate the optimal path giving a set of tapas.
        /// </summary>
        /// <param name="journeyParameters">journey parameters send by the user</param>
        /// <returns></returns>
        TapasResponse GetTapasRoute(JourneyParameters journeyParameters);
    }
}