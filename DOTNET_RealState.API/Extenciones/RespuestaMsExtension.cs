using DOTNET_RealState.Aplicacion.Envoltorios;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_RealState.API.Extenciones
{
    public static class RespuestaMsExtension
    {
        /// <summary>
        /// Convierte una instancia de <see cref="RespuestaMs{T}"/> en un <see cref="IActionResult"/> para ser retornado desde un controlador.
        /// </summary>
        /// <typeparam name="T">Tipo de dato contenido en la propiedad <c>Resultado</c> de la respuesta.</typeparam>
        /// <param name="respuesta">Objeto de tipo <see cref="RespuestaMs{T}"/> que representa la respuesta del servicio o lógica de aplicación.</param>
        /// <returns>
        /// Un objeto <see cref="IActionResult"/> correspondiente al resultado:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="ObjectResult"/> con el contenido del resultado y el código de estado si la operación fue exitosa (incluyendo 201).</description>
        /// </item>
        /// <item>
        /// <description><see cref="ObjectResult"/> con un objeto anónimo que contiene los errores, si la operación no fue exitosa.</description>
        /// </item>
        /// </list>
        /// </returns>
        public static IActionResult ConvertirRespuestaActionResult<T>(this RespuestaMs<T> respuesta)
        {
            return new ObjectResult(respuesta) { StatusCode = (int)respuesta.StatusCode };
        }
    }
}
