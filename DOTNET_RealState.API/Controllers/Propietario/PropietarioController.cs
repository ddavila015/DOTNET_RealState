using DOTNET_RealState.API.Extenciones;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropietario;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_RealState.API.Controllers.Propietario
{
    public class PropietarioController : BaseApiController
    {
        /// <summary>
        /// Registrar una Propiedad
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="500">Error interno en el API</response>
        /// <response code="404">Error controlado cuando el Request es invalido</response>
        /// <response code="400">Error controlado por el flitro del request</response>
        [Route("RegistrarPropietario")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarPropietario([FromBody] RegistrarPropietarioSolicitud solicitud)
        {
            return RespuestaMsExtension.ConvertirRespuestaActionResult(await Mediador.Send(solicitud));
        }
    }
}
