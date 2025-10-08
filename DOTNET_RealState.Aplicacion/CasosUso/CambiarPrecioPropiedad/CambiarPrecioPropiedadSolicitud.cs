using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.CambiarPrecioPropiedad
{
    public class CambiarPrecioPropiedadSolicitud : IRequest<RespuestaMs<CambiarPrecioPropiedadRespuesta>>
    {
        public string IdPropiedad { get; set; }
        public decimal Precio { get; set; }

    }
}
