using System.Net;

namespace DOTNET_RealState.Aplicacion.Envoltorios
{
	/// <summary>
	/// Representa la estructura base de una respuesta de microservicio genérica.
	/// </summary>
	/// <typeparam name="T">Tipo del dato de resultado.</typeparam>
	public class RespuestaMsBase<T>
	{
		/// <summary>
		/// Indica si la operación fue exitosa.
		/// </summary>
		public bool OperacionExitosa { get; set; }

		/// <summary>
		/// Mensaje general relacionado con la operación.
		/// </summary>
		public string? Mensaje { get; set; }

		/// <summary>
		/// Lista de errores que ocurrieron durante la operación.
		/// </summary>
		public IEnumerable<string> Errores { get; set; } = [];

		/// <summary>
		/// Resultado de la operación, si es aplicable.
		/// </summary>
		public T? Resultado { get; set; }

		/// <summary>
		/// Codigo de estado HTTP asociado a la respuesta.
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }
	}
}
