using DOTNET_RealState.Aplicacion.CasosUso.CambiarPrecioPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.CargarImagenPropiedad
{
    public class CargarImagenPropiedadSolicitud : IRequest<RespuestaMs<CargarImagenPropiedadRespuesta>>
    {
        public string IdPropiedad { get; set; }
        public string ArchivoNombre { get; set; }
        public string ImgBase64 { get; set; }                
    }
}
