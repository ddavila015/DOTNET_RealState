using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.Propiedades
{
    public class RegistrarPropiedadManejador : IRequestHandler<RegistrarPropiedadSolicitud, Respuesta<RegistrarPropiedadRespuesta>>
    {     
        public Task<Respuesta<RegistrarPropiedadRespuesta>> Handle(RegistrarPropiedadSolicitud request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
