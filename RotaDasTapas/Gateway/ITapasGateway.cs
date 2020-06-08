using System.Collections.Generic;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Gateway
{
    public interface ITapasGateway
    {
        IEnumerable<TapaDto> GetAllTapas();
        IEnumerable<TapaDto> GetTapasRoute(string city);
    }
}