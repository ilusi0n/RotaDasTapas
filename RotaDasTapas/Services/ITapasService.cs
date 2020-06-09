using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;

namespace RotaDasTapas.Services
{
    public interface ITapasService
    {
        TapasResponse GetAllTapas(TapasParameters tapasParameters);
        TapasResponse GetTapasRoute(JourneyParameters journeyParameters);
    }
}