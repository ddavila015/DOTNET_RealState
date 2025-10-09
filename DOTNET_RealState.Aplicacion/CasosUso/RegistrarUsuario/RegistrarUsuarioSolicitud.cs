using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.RegistrarUsuario
{
    public class RegistrarUsuarioSolicitud : IRequest<RespuestaMs<RegistrarUsuarioRespuesta>>
    {

        public string Username { get; set; }
    
        public string Password{ get; set; }
     
        public string Rol { get; set; }
    }
}
