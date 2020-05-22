using System.Collections.Generic;
using RotaDasTapas.Models;

namespace RotaDasTapas.Services
{
    public interface ITapasService
    {
        IEnumerable<Tapa> GetAllTapas();
        Tapa GetTapaByName(string name);
    }
}