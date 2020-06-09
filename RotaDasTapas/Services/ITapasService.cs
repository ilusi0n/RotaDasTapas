using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;

namespace RotaDasTapas.Services
{
    public interface ITapasService
    {
        TapasResponse GetAllTapas(RotaDasTapasParameters rotaDasTapasParameters);
        TapasResponse GetTapasRoute(string city, string list);
    }
}