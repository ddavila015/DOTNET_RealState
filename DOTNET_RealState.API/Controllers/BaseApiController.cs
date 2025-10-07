using DOTNET_RealState.Aplicacion.Constantes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_RealState.API.Controllers
{
    /// <summary>
    /// Clase base para todos los controladores de la API.
    /// Proporciona configuración común y acceso al patrón Mediator mediante <see cref="IMediator"/>.
    /// </summary>
    //[Authorize(Policy = "TokenOrInternal")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediador;

        /// <summary>
        /// Proveedor del patrón Mediator para manejar peticiones y respuestas dentro de la arquitectura CQRS.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Lanza una excepción si el servicio <see cref="IMediator"/> no está registrado en el contenedor de dependencias.
        /// </exception>
        protected IMediator Mediador =>
            _mediador ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException(Mensajes.MensajeMediador);
    }
}
