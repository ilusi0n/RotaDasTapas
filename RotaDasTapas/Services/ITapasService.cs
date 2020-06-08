using System.Collections.Generic;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Response;

namespace RotaDasTapas.Services
{
    public interface ITapasService
    {
        TapasResponse GetAllTapas();
        TapasResponse GetTapaByName(string name);
        TapasResponse GetTapaByCity(string city);
    }
}