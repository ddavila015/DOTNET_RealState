using DOTNET_RealState.Aplicacion.CasosUso.Propiedades;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_RealState.API.Controllers.Propiedad
{
    public class PropiedadesController : BaseApiController
    {
        /// <summary>
        /// Realiza el envío de una notificación
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="500">Error interno en el API</response>
        /// <response code="404">Error controlado cuando el Request es invalido</response>
        /// <response code="400">Error controlado por el flitro del request</response>
        [Route("RegistrarPropiedad")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarPropiedad([FromBody] RegistrarPropiedadSolicitud solicitud)
        {

            return Ok(await Mediador.Send(new RegistrarPropiedadSolicitud()));
            
        }
    }
}
