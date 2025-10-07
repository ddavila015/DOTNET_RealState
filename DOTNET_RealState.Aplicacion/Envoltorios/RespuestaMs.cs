using DOTNET_RealState.Aplicacion.Constantes;
using System.Net;


namespace DOTNET_RealState.Aplicacion.Envoltorios
{
	/// <summary>
	/// Representa una respuesta estándar utilizada en microservicios, heredando de <see cref="RespuestaMsBase{T}"/>.
	/// Contiene información sobre el éxito de la operación, mensajes, errores, resultado y código HTTP.
	/// </summary>
	/// <typeparam name="T">Tipo del dato retornado en la propiedad <c>Resultado</c>.</typeparam>
	public class RespuestaMs<T> : RespuestaMsBase<T>
	{
		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		public RespuestaMs()
		{ }

		/// <summary>
		/// Inicializa una nueva instancia de <see cref="RespuestaMs{T}"/> con todos los campos configurados.
		/// </summary>
		/// <param name="operacionExitosa">Indica si la operación fue exitosa.</param>
		/// <param name="mensaje">Mensaje informativo asociado a la operación.</param>
		/// <param name="errores">Lista de errores ocurridos (si los hay).</param>
		/// <param name="resultado">Objeto resultado de la operación.</param>
		/// <param name="httpStatusCode">Código de estado HTTP correspondiente a la operación.</param>
		public RespuestaMs(bool operacionExitosa, string? mensaje,
			IEnumerable<string>? errores, T? resultado, HttpStatusCode httpStatusCode)
		{
			OperacionExitosa = operacionExitosa;
			Mensaje = mensaje;
			Errores = errores;
			Resultado = resultado;
			StatusCode = httpStatusCode;

		}

		/// <summary>
		/// Crea una instancia exitosa de <see cref="RespuestaMs{T}"/>.
		/// </summary>
		/// <param name="resultado">Resultado de la operación.</param>
		/// <param name="mensaje">Mensaje informativo.</param>
		/// <param name="statusCode">Código de estado HTTP (por defecto 200 OK).</param>
		/// <returns>Instancia de respuesta exitosa.</returns>
		public static RespuestaMs<T> CrearRespuestaExitosa(T resultado, string mensaje, HttpStatusCode statusCode = HttpStatusCode.OK) =>
			new(operacionExitosa: true, mensaje, null, resultado, statusCode);

		/// <summary>
		/// Crea una instancia de <see cref="RespuestaMs{T}"/> representando un error interno del servidor.
		/// </summary>
		/// <param name="resultado">Resultado parcial o nulo.</param>
		/// <param name="mensaje">Mensaje de error descriptivo.</param>
		/// <param name="statusCode">Código de estado HTTP (por defecto 500 InternalServerError).</param>
		/// <returns>Instancia de respuesta con error interno.</returns>
		public static RespuestaMs<T> CrearRespuestaErrorInterno(T resultado, string mensaje, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) =>
			new(operacionExitosa: false, mensaje, null, resultado, statusCode);

		/// <summary>
		/// Crea una respuesta exitosa pero sin contenido útil para mostrar.
		/// Equivale al código HTTP 204 o 404 dependiendo del contexto.
		/// </summary>
		/// <param name="resultado">Resultado retornado, aunque vacío.</param>
		/// <param name="mensaje">Mensaje opcional de advertencia o contexto.</param>
		/// <returns>Instancia de respuesta sin contenido.</returns>
		public static RespuestaMs<T> CrearRespuestaSinContenido(T resultado, string? mensaje = Mensajes.SinDatos) =>
			new(operacionExitosa: false, mensaje, null, resultado, HttpStatusCode.NotFound);
		/// <summary>
		/// Crea una instancia de respuesta fallida con estado 404 (NotFound).
		/// </summary>
		/// <param name="resultado">Resultado retornado, si aplica.</param>
		/// <param name="mensaje">Mensaje que describe la causa del fallo.</param>
		/// <returns>Instancia de respuesta indicando que el recurso no fue encontrado.</returns>
		public static RespuestaMs<T> CrearRespuestaNoEncontrada(T resultado, string mensaje) =>
			new(operacionExitosa: false, mensaje, null, resultado, HttpStatusCode.NotFound);

		/// <summary>
		/// Crea una instancia de respuesta fallida con estado 400 (BadRequest).
		/// </summary>
		/// <param name="resultado">Resultado relacionado con la solicitud fallida.</param>
		/// <param name="mensaje">Mensaje explicando la solicitud inválida.</param>
		/// <returns>Instancia de respuesta indicando que la solicitud no fue válida.</returns>
		public static RespuestaMs<T> CrearRespuestaSolicitudInvalida(T resultado, string mensaje) =>
			new(operacionExitosa: false, mensaje, null, resultado, HttpStatusCode.BadRequest);

		/// <summary>
		/// Crea una instancia de respuesta de error genérico, permitiendo especificar el código de estado HTTP.
		/// </summary>
		/// <param name="resultado">Resultado que puede acompañar el error.</param>
		/// <param name="mensaje">Mensaje de error personalizado.</param>
		/// <param name="statusCode">Código HTTP que representa el tipo de error. Por defecto 400.</param>
		/// <returns>Instancia de respuesta con error genérico.</returns>
		public static RespuestaMs<T> CrearRespuestaErrorGenerico(T resultado, string mensaje, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
			new(operacionExitosa: false, mensaje, null, resultado, statusCode);

		/// <summary>
		/// Crea una instancia de respuesta de no autorizado con estado 401 (Unauthorized).
		/// </summary>
		/// <param name="resultado">Resultado que puede acompañar el error.</param>
		/// <param name="mensaje">Mensaje de error personalizado.</param>
		/// <returns>Instancia de respuesta indicando que la solicitud no fue autorizada.</returns>
		public static RespuestaMs<T> CrearRespuestaNoAutorizado(T resultado, string mensaje = Mensajes.Token) =>
			new(operacionExitosa: false, mensaje, null, resultado, HttpStatusCode.Unauthorized);

	}
}
