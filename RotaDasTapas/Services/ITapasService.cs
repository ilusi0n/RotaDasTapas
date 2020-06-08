using System.Collections.Generic;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Response;

namespace RotaDasTapas.Services
{
    public interface ITapasService
    {
        TapasResponse GetAllTapas();
        TapasResponse GetTapasRoute(string city, string list);
    }
}