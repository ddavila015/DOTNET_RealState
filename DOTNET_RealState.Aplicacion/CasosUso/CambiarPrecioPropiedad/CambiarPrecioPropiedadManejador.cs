using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.CambiarPrecioPropiedad
{
    public class CambiarPrecioPropiedadManejador(IPropiedades propiedades) : IRequestHandler<CambiarPrecioPropiedadSolicitud, RespuestaMs<CambiarPrecioPropiedadRespuesta>>
    {
        private readonly IPropiedades _propiedades = propiedades;

        public async Task<RespuestaMs<CambiarPrecioPropiedadRespuesta>> Handle(CambiarPrecioPropiedadSolicitud solicitud, CancellationToken cancellationToken)
        {

            try
            {
                var respuesta = _propiedades.CambiarPrecioPropiedad(solicitud);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }

            return RespuestaMs<CambiarPrecioPropiedadRespuesta>.CrearRespuestaExitosa(new CambiarPrecioPropiedadRespuesta(), string.Empty);
        }
    }
}
