using System.Collections.Generic;
using RotaDasTapas.Models;

namespace RotaDasTapas.Repository
{
    public interface ITapasRepository
    {
        IEnumerable<Tapa> GetAllTapas();
    }
}