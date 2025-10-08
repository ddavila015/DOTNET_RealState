using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using DOTNET_RealState.Aplicacion.Puertos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.CargarImagenPropiedad
{
    public class CargarImagenPropiedadManejador(IPropiedades propiedades) : IRequestHandler<CargarImagenPropiedadSolicitud, RespuestaMs<CargarImagenPropiedadRespuesta>>
    {
        private readonly IPropiedades _propiedades = propiedades;

        public async Task<RespuestaMs<CargarImagenPropiedadRespuesta>> Handle(CargarImagenPropiedadSolicitud solicitud, CancellationToken cancellationToken)
        {
            try
            {

                var respuesta = _propiedades.CargarImagenPropiedad(solicitud);
            }
            catch (Exception ex)
            {
                throw;
            }

            return RespuestaMs<CargarImagenPropiedadRespuesta>.CrearRespuestaExitosa(new CargarImagenPropiedadRespuesta(), string.Empty);
        }
    }
}
