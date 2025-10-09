using DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropietario;
using DOTNET_RealState.Aplicacion.Envoltorios;
using DOTNET_RealState.Aplicacion.Puertos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad
{
    public class ActualizarPropiedadManejador(IPropiedades propiedades) : IRequestHandler<ActualizarPropiedadSolicitud, RespuestaMs<ActualizarPropiedadRespuesta>>
    {
        private readonly IPropiedades _propiedades = propiedades;
        public async Task<RespuestaMs<ActualizarPropiedadRespuesta>> Handle(ActualizarPropiedadSolicitud solicitud, CancellationToken cancellationToken)
        { 
            try
            {
                var resultado = _propiedades.ActualizarPropiedad(solicitud);                
                return RespuestaMs<ActualizarPropiedadRespuesta>.CrearRespuestaExitosa(new ActualizarPropiedadRespuesta { Propiedad = resultado.Result}, string.Empty);
            }
            catch (Exception ex)
            {
                return RespuestaMs<ActualizarPropiedadRespuesta>.CrearRespuestaErrorInterno(new ActualizarPropiedadRespuesta(), $"{ex.Message} - {ex.InnerException}");
            }          
        }
    }
}
