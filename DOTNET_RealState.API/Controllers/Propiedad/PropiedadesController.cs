using DOTNET_RealState.API.Extenciones;
using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.CambiarPrecioPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.CargarImagenPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad;
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
        /// Registrar una Propiedad
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
            return RespuestaMsExtension.ConvertirRespuestaActionResult(await Mediador.Send(solicitud));
        }

        /// <summary>
        /// Consultar Propiedades
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="500">Error interno en el API</response>
        /// <response code="404">Error controlado cuando el Request es invalido</response>
        /// <response code="400">Error controlado por el flitro del request</response>
        [Route("ConsultarPropiedad")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultarPropiedades([FromBody] ConsultarPropiedadSolicitud solicitud)
        {
            return RespuestaMsExtension.ConvertirRespuestaActionResult(await Mediador.Send(solicitud));
        }


        /// <summary>
        /// Actualizar Propiedades
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="500">Error interno en el API</response>
        /// <response code="404">Error controlado cuando el Request es invalido</response>
        /// <response code="400">Error controlado por el flitro del request</response>
        [Route("ActualizarPropiedad")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarPropiedad([FromBody] ActualizarPropiedadSolicitud solicitud)
        {
            return RespuestaMsExtension.ConvertirRespuestaActionResult(await Mediador.Send(solicitud));
        }



        /// <summary>
        /// Cambiar Precio Propiedad
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="500">Error interno en el API</response>
        /// <response code="404">Error controlado cuando el Request es invalido</response>
        /// <response code="400">Error controlado por el flitro del request</response>
        [Route("CambiarPrecioPropiedad")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CambiarPrecioPropiedad([FromBody] CambiarPrecioPropiedadSolicitud solicitud)
        {
            return RespuestaMsExtension.ConvertirRespuestaActionResult(await Mediador.Send(solicitud));
        }



        /// <summary>
        /// Cambiar Precio Propiedad
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="500">Error interno en el API</response>
        /// <response code="404">Error controlado cuando el Request es invalido</response>
        /// <response code="400">Error controlado por el flitro del request</response>
        [Route("CargarImagenPropiedad")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CargarImagenPropiedad([FromBody] CargarImagenPropiedadSolicitud solicitud)
        {
            return RespuestaMsExtension.ConvertirRespuestaActionResult(await Mediador.Send(solicitud));
        }

    }
}
