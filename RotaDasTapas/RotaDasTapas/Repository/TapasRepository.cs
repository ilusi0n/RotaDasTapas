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
            _listTapas = TapasUtils.Init();
        }

        public IEnumerable<Tapa> GetAllTapas()
        {
            return _listTapas;
        }
        
        public Tapa GetTapaByName(string name)
        {
            return _listTapas.FirstOrDefault(tapa => tapa.Name.Equals(name));
        }
    }
}