using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Dtos
{
    public class PropiedadDTO
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal Precio { get; set; }
        public string CodigoInterno { get; set; }
        public string ano { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPropietario { get; set; }
        public PropietarioDTO Propietario { get; set; }
        public List<ImagenPropiedadDTO> Imagenes { get; set; }
    }
}
