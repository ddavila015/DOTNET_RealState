using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Dtos;
using DOTNET_RealState.Aplicacion.Envoltorios;
using DOTNET_RealState.Aplicacion.Puertos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad
{
    public class ConsultarPropiedadesManejador(IPropiedades propiedades) : IRequestHandler<ConsultarPropiedadSolicitud, RespuestaMs<ConsultarPropiedadRespuesta>>
    {
        private readonly IPropiedades _propiedades = propiedades;

        public async Task<RespuestaMs<ConsultarPropiedadRespuesta>> Handle(ConsultarPropiedadSolicitud solicitud, CancellationToken cancellationToken)
        {
            ConsultarPropiedadRespuesta respuesta = new ConsultarPropiedadRespuesta();

            try
            {
               var resultado = _propiedades.ConsultartPropiedades(solicitud);            
               return RespuestaMs<ConsultarPropiedadRespuesta>.CrearRespuestaExitosa(new ConsultarPropiedadRespuesta { Propiedades = resultado }, string.Empty);
            }
            catch (Exception ex)
            {                
                return RespuestaMs<ConsultarPropiedadRespuesta>.CrearRespuestaErrorInterno(respuesta, $"{ex.Message} - {ex.InnerException}");
            }           
        } 
    }
}
