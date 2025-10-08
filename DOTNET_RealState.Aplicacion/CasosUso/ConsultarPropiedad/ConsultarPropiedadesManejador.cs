using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
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
            try
            {

                _propiedades.ConsultartPropiedades(solicitud);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }

            return RespuestaMs<ConsultarPropiedadRespuesta>.CrearRespuestaExitosa(new ConsultarPropiedadRespuesta(), string.Empty);
        }
    }
}
