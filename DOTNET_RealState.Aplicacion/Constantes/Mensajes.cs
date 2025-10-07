using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Constantes
{
    public static class Mensajes
    {
        /// <summary>Mensaje cuando el servicio de MediatR no está registrado.</summary>
		public const string MensajeMediador = "IMediator no está registrado en el contenedor de servicios.";


        /// <summary>
		/// Mensaje que indica que no retorno datos.
		/// </summary>
		public const string SinDatos = "No se retornaron datos";


        /// <summary>
        /// Mensaje que indca que el token ha expirado.
        /// </summary>
        public const string Token = "El Token Expiró.";

    }
}
