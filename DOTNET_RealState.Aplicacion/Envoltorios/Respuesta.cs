namespace DOTNET_RealState.Aplicacion.Envoltorios
{
	/// <summary>
	/// Clase genérica que representa una respuesta estándar de una operación.
	/// </summary>
	/// <typeparam name="T">Tipo del dato de resultado esperado.</typeparam>
	public class Respuesta<T>
	{
		/// <summary>
		/// Constructor por defecto. Inicializa la respuesta como exitosa y sin errores.
		/// </summary>
		public Respuesta()
		{
			OperacionExitosa = true;
			Mensaje = string.Empty;
			Errores = [];
		}

		/// <summary>
		/// Constructor para una respuesta exitosa con datos y mensaje opcional.
		/// </summary>
		/// <param name="datos">Datos devueltos como resultado.</param>
		/// <param name="mensaje">Mensaje adicional informativo.</param>
		public Respuesta(T datos, string? mensaje = null)
		{
			OperacionExitosa = true;
			Mensaje = mensaje;
			Errores = [];
			Resultado = datos;
		}

		/// <summary>
		/// Constructor para una respuesta fallida con mensaje de error.
		/// </summary>
		/// <param name="message">Mensaje de error que describe la causa de la falla.</param>
		public Respuesta(string message)
		{
			OperacionExitosa = false;
			Mensaje = message;
			Errores = [];
		}

		/// <summary>
		/// Indica si la operación fue exitosa o no.
		/// </summary>
		public bool OperacionExitosa { get; set; }

		/// <summary>
		/// Mensaje descriptivo adicional (de éxito o error).
		/// </summary>
		public string? Mensaje { get; set; }

		/// <summary>
		/// Lista de errores detallados si la operación falló.
		/// </summary>
		public List<string> Errores { get; set; }

		/// <summary>
		/// Resultado genérico de la operación, puede ser nulo si hubo error.
		/// </summary>
		public T? Resultado { get; set; }


	}
}
