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

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPropiedad { get; set; }
        public string ArchivoNombre { get; set; }
        public string ImgBase64 { get; set; }
        public bool Activo { get; set; }
    }
}
