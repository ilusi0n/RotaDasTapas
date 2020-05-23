using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotaDasTapas.Constants;
using RotaDasTapas.Errors;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Request;
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
        [ProducesResponseType(typeof(IEnumerable<Tapa>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public IActionResult GetTapas()
        {
            var result = _tapasService.GetAllTapas();
            if (result == null)
            {
                return new ObjectResult(new InternalServerError(ErrorConstants.InternalError));
            }
            return Ok(_tapasService.GetAllTapas());
        }

        [HttpGet]
        [Route("TapaByName")]
        [ProducesResponseType(typeof(Tapa), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public IActionResult GetTapaByName([FromQuery] RotaDasTapasRequest rotaDasTapasRequest)
        {
            var result = _tapasService.GetTapaByName(rotaDasTapasRequest.Name);
            if (result == null)
            {
                return NotFound(new NotFoundError(ErrorConstants.NotFound));
            }
            return Ok(result);
        }
    }
}