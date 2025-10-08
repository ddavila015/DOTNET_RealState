using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Infraestructura.Persistencia
{   
    public class MongoDBContext : IMongoDBContext
    {
        private readonly string conexion = Environment.GetEnvironmentVariable("MongoDB_Conexion");
        private readonly string DBNombre = Environment.GetEnvironmentVariable("MongoDB_Nombre_BaseDato");

        private readonly IMongoDatabase _database;

        /// <summary>
        /// Creamos una conexion de la base de datos
        /// </summary>
        public MongoDBContext()
        {
            var client = new MongoClient(conexion);
            _database = client.GetDatabase(DBNombre);
        }

        /// <summary>
        /// Creamos una collecion de la entidad
        /// </summary>
        public IMongoCollection<T> GetCollection<T>(string nombre)
        {
            return _database.GetCollection<T>(nombre);
        } 
    }
}
