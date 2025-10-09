using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
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

namespace DOTNET_RealState.Aplicacion.CasosUso.CargarImagenPropiedad
{
    public class CargarImagenPropiedadManejador(IPropiedades propiedades) : IRequestHandler<CargarImagenPropiedadSolicitud, RespuestaMs<CargarImagenPropiedadRespuesta>>
    {
        private readonly IPropiedades _propiedades = propiedades;

        public async Task<RespuestaMs<CargarImagenPropiedadRespuesta>> Handle(CargarImagenPropiedadSolicitud solicitud, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = _propiedades.CargarImagenPropiedad(solicitud);
                return RespuestaMs<CargarImagenPropiedadRespuesta>.CrearRespuestaExitosa(new CargarImagenPropiedadRespuesta { ImagenPropiedad = resultado.Result }, string.Empty);
            }
            catch (Exception ex)
            {                 
                return RespuestaMs<CargarImagenPropiedadRespuesta>.CrearRespuestaErrorInterno(new CargarImagenPropiedadRespuesta(), $"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}
