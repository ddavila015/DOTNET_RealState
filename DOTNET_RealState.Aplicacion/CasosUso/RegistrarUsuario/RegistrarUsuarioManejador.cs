using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using DOTNET_RealState.Aplicacion.Puertos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.RegistrarUsuario
{
    public class RegistrarUsuarioManejador(IUsuarios usuarios) : IRequestHandler<RegistrarUsuarioSolicitud, RespuestaMs<RegistrarUsuarioRespuesta>>
    {
        public async Task<RespuestaMs<RegistrarUsuarioRespuesta>> Handle(RegistrarUsuarioSolicitud solicitud, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = usuarios.RegistrarUsuarios(solicitud);
                return RespuestaMs<RegistrarUsuarioRespuesta>.CrearRespuestaExitosa(new RegistrarUsuarioRespuesta { usuario = resultado.Result }, string.Empty);
            }
            catch (Exception ex)
            {
                return RespuestaMs<RegistrarUsuarioRespuesta>.CrearRespuestaErrorInterno(new RegistrarUsuarioRespuesta(), $"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}
