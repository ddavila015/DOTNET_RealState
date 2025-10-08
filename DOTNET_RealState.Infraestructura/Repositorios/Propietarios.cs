using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropietario;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Infraestructura.Repositorios
{
    public class Propietarios(IMongoDBContext mongoDBContext) : IPropietarios
    {
        /// <summary>
        /// obtenemos una conexion de la base de datos
        /// </summary>
        private readonly IMongoDBContext _mongoDBContext = mongoDBContext;

        public async Task<Propietario> RegistrarPropietario(RegistrarPropietarioSolicitud solicitud)
        {
            try
            { 
                /// <summary>
                /// obtenermos la collection de la entidad Propietario
                /// </summary>
                var coleccion = mongoDBContext.GetCollection<Propietario>("Propietarios");

                /// <summary>
                /// Mapeamos la entidad 
                /// </summary>
                var propietario = new Propietario
                {
                    Nombre = solicitud.Nombre,
                    Direccion = solicitud.Direccion,
                    Foto = solicitud.FotoNombre,
                    FotoBase64 = solicitud.FotoBase64,
                    FechaNacimiento = solicitud.FechaNacimiento                
                };

                /// <summary>
                /// Insertamos el objecto
                /// </summary>
                await coleccion.InsertOneAsync(propietario);

                return propietario;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}
