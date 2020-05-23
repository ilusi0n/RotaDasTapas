using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Models;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Repository
{
    public class TapasRepository : ITapasRepository
    {
        private readonly IEnumerable<Tapa> _listTapas;

        public TapasRepository()
        {
            //_listTapas = TapasUtils.Init();
            _listTapas = TapasUtils.InitMock();
        }

        public IEnumerable<Tapa> GetAllTapas()
        {
            return _listTapas.OrderBy(tapa => tapa.City).ThenBy(tapa => tapa.Name);
        }
        
        public Tapa GetTapaByName(string name)
        {
            return _listTapas.FirstOrDefault(tapa => tapa.Name.Equals(name));
        }

        public IEnumerable<Tapa> GetTapasByCity(string city)
        {
            return _listTapas.Where(tapa => tapa.City.Equals(city)).OrderBy(tapa => tapa.Name);
        }
    }
}