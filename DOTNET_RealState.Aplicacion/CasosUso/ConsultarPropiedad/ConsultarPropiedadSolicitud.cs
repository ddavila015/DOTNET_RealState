using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Envoltorios;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad
{
    public class ConsultarPropiedadSolicitud : IRequest<RespuestaMs<ConsultarPropiedadRespuesta>>
    {
        public decimal PrecioMaximo { get; set; }
         
        public string ano { get; set; }
    }
}
