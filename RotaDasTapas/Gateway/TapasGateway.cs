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
            //_listTapas = TapasUtils.Init();
            _listTapas = TapasUtils.InitMock();
        }

        public IEnumerable<TapaDto> GetAllTapas()
        {
            return _listTapas;
        }
        
        public TapaDto GetTapaByName(string name)
        {
            return _listTapas.FirstOrDefault(tapa => tapa.Name.Equals(name));
        }

        public IEnumerable<TapaDto> GetTapasByCity(string city)
        {
            return _listTapas.Where(tapa => tapa.City.Equals(city));
        }
    }
}