using System.Linq;
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

        /// <summary>
        ///     Get all Tapas ordered by City, Name
        /// </summary>
        [HttpGet]
        [Route("Tapas")]
        [ProducesResponseType(typeof(TapasResponse), StatusCodes.Status200OK)]
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

        /// <summary>
        ///     Get a Tapa by The name
        ///     Returns not found if the tapa doesnt exist
        /// </summary>
        [HttpGet]
        [Route("Tapa/Name/{name}")]
        [ProducesResponseType(typeof(TapasResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(UnauthorizedError), StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(AuthorizationFilterAttribute))]
        public IActionResult GetTapaByName(
            [FromHeader] RotaDasTapasHeaders rotaDasTapasHeaders,
            string name)
        {
            var result = _tapasService.GetTapaByName(name);
            if (!result.Tapas.Any())
            {
                return NotFound(new NotFoundError(ErrorConstants.NotFound));
            }

            return Ok(result);
        }

        /// <summary>
        ///     Get all Tapas ordered by name from that city
        ///     Returns an empty list if there isn't any
        /// </summary>
        [HttpGet]
        [Route("Tapa/City/{city}")]
        [ProducesResponseType(typeof(TapasResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(UnauthorizedError), StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(AuthorizationFilterAttribute))]
        public IActionResult GetTapasByCity(
            [FromHeader] RotaDasTapasHeaders rotaDasTapasHeaders,
            string city)
        {
            var result = _tapasService.GetTapaByCity(city);
            return Ok(result);
        }
    }
}