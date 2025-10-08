using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropietario
{
    public class RegistrarPropietarioSolicitud : IRequest<RespuestaMs<RegistrarPropietarioRespuesta>>
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string FotoNombre { get; set; }

        public string FotoBase64 { get; set; }
        public string FechaNacimiento { get; set; }
    }
}
