using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.Propiedades
{
    public class RegistrarPropiedadManejador(IPropiedades propiedades) : IRequestHandler<RegistrarPropiedadSolicitud, RespuestaMs<RegistrarPropiedadRespuesta>>
    {
        private readonly IPropiedades _propiedades = propiedades;

        public async Task<RespuestaMs<RegistrarPropiedadRespuesta>> Handle(RegistrarPropiedadSolicitud solicitud, CancellationToken cancellationToken)
        {
            try
            {
                
              var respuesta = _propiedades.RegistrarPropiedad(solicitud);                 
            }
            catch (Exception ex)
            {
                throw;
            }

            return RespuestaMs<RegistrarPropiedadRespuesta>.CrearRespuestaExitosa(new RegistrarPropiedadRespuesta(), string.Empty);                
        }
    }
}
