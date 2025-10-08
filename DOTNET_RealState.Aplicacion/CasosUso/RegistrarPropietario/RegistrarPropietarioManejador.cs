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

namespace DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropietario
{
    public class RegistrarPropietarioManejador(IPropietarios propietarios) : IRequestHandler<RegistrarPropietarioSolicitud, RespuestaMs<RegistrarPropietarioRespuesta>>
    {
        private readonly IPropietarios _propietarios = propietarios;

        public async Task<RespuestaMs<RegistrarPropietarioRespuesta>> Handle(RegistrarPropietarioSolicitud solicitud, CancellationToken cancellationToken)
        {
            try
            {

                var respuesta = _propietarios.RegistrarPropietario(solicitud);
            }
            catch (Exception ex)
            {
                throw;
            }

            return RespuestaMs<RegistrarPropietarioRespuesta>.CrearRespuestaExitosa(new RegistrarPropietarioRespuesta(), string.Empty);
        }
    }
}
