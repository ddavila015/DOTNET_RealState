using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Dominio.Entidades
{
    public class RefreshToken
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UsuarioId { get; set; }

        /// <summary>
        ///  //Guardar en hash (ej. SHA256)
        /// </summary>
        public string TokenHash { get; set; }  
        public DateTime Expiracion { get; set; }
        public bool Revocado { get; set; } = false;
    }
}
