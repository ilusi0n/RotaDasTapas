using System.Collections.Generic;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Gateway
{
    public interface ITapasGateway
    {
        IEnumerable<TapaDto> GetAllTapas();
        TapaDto GetTapaByName(string name);
        IEnumerable<TapaDto> GetTapasByCity(string city);
    }
}