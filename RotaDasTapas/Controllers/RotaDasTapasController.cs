using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotaDasTapas.Constants;
using RotaDasTapas.Errors;
using RotaDasTapas.Filters;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;
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
        ///     Get all Tapas ordered by City, Name.
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
        ///     Calculate the optimal path from the selected Tapas
        /// </summary>
        [HttpGet]
        [Route("Tapas/Journey/{city}")]
        [ProducesResponseType(typeof(TapasResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(UnauthorizedError), StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(AuthorizationFilterAttribute))]
        public IActionResult GetTapasRoute(
            [FromHeader] RotaDasTapasHeaders rotaDasTapasHeaders, string city, string list)
        {
            var result = _tapasService.GetTapasRoute(city,list);
            return Ok(result);
        }
    }
}