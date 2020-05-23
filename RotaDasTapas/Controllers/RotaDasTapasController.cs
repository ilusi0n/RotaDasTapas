using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotaDasTapas.Constants;
using RotaDasTapas.Errors;
using RotaDasTapas.Filters;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Services;

namespace RotaDasTapas.Controllers
{
    //[ApiVersion("1.0")]
    [ApiController]
    //[Route("api/v{version:apiVersion}/[Controller]")]
    [Route("api/v1/[Controller]")]
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
        [ProducesResponseType(typeof(UnauthorizedError), StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(AuthorizationFilterAttribute))]
        public IActionResult GetTapas(
            [FromHeader] RotaDasTapasHeaders rotaDasTapasHeaders)
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
        [ProducesResponseType(typeof(UnauthorizedError), StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(AuthorizationFilterAttribute))]
        public IActionResult GetTapaByName(
            [FromHeader] RotaDasTapasHeaders rotaDasTapasHeaders,
            [FromQuery] RotaDasTapasByNameRequest rotaDasTapasByNameRequest)
        {
            var result = _tapasService.GetTapaByName(rotaDasTapasByNameRequest.Name);
            if (result == null)
            {
                return NotFound(new NotFoundError(ErrorConstants.NotFound));
            }

            return Ok(result);
        }
        
        [HttpGet]
        [Route("TapasByCity")]
        [ProducesResponseType(typeof(IEnumerable<Tapa>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(UnauthorizedError), StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(AuthorizationFilterAttribute))]
        public IActionResult GetTapasByCity(
            [FromHeader] RotaDasTapasHeaders rotaDasTapasHeaders,
            [FromQuery] RotaDasTapasByCityRequest rotaDasTapasByCityRequest)
        {
            var result = _tapasService.GetTapaByCity(rotaDasTapasByCityRequest.City);
            return Ok(result);
        }
    }
}