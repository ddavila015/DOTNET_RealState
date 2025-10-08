using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Dominio.Entidades
{
    public class ImagenPropiedad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IdPropiedad { get; set; }
        public string Archivo { get; set; }
        public string Activo { get; set; }
    }
}
