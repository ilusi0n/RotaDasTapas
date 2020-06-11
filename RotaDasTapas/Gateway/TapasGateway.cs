using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Gateway
{
    public class TapasGateway : ITapasGateway
    {
        private readonly IEnumerable<TapaDto> _listTapas;

        public TapasGateway()
        {
            _listTapas = TapasUtils.Init();
        }

        public IEnumerable<TapaDto> GetAllTapas()
        {
            return _listTapas;
        }

        public IEnumerable<TapaDto> GetTapasRoute(string city)
        {
            return _listTapas.Where(tapa => tapa.City.Equals(city));
        }
    }
}