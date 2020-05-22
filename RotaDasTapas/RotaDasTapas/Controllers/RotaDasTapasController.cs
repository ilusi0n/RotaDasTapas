using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RotaDasTapas.Models;
using RotaDasTapas.Services;

namespace RotaDasTapas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RotaDasTapasController : ControllerBase
    {
        private readonly ITapasService _tapasService;

        public RotaDasTapasController(ITapasService tapasService)
        {
            _tapasService = tapasService;
        }

        [HttpGet]
        [Route("Tapas")]
        public IEnumerable<Tapa> GetTapas()
        {
            return _tapasService.GetAllTapas();
        }
    }
}