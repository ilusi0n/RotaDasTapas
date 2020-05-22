using System.Collections.Generic;
using RotaDasTapas.Models;
using RotaDasTapas.Repository;

namespace RotaDasTapas.Services
{
    public class TapasService : ITapasService
    {
        private readonly ITapasRepository _tapasRepository;
        public TapasService(ITapasRepository tapasRepository)
        {
            _tapasRepository = tapasRepository;
        }
        public IEnumerable<Tapa> GetAllTapas()
        {
            return _tapasRepository.GetAllTapas();
        }
    }
}