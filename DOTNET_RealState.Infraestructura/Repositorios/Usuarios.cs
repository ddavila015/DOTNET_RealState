using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarUsuario;
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
    public class Usuarios(IMongoDBContext mongoDBContext) : IUsuarios
    {
        /// <summary>
        /// obtenemos una conexion de la base de datos
        /// </summary>
        private readonly IMongoDBContext _mongoDBContext = mongoDBContext;


        public async Task<Usuario> RegistrarUsuarios(RegistrarUsuarioSolicitud solicitud)
        {
            try
            {
                /// <summary>
                /// obtenermos la collection de la entidad Usuario
                /// </summary>
                var coleccion = _mongoDBContext.GetCollection<Usuario>("usuarios");

              
                /// <summary>
                /// Mapeamos la entidad 
                /// </summary>
                var usuario = new Usuario
                {
                    Username = solicitud.Username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(solicitud.Password),
                    Rol = solicitud.Rol                    
                };

                /// <summary>
                /// Insertamos el objecto
                /// </summary>
                await coleccion.InsertOneAsync(usuario);

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}
