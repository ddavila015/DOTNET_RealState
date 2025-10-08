using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
using DOTNET_RealState.Infraestructura.Persistencia;
using MongoDB.Driver;
using NHibernate.Id;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DOTNET_RealState.Infraestructura.Repositorios
{

    public class Propiedades(IMongoDBContext mongoDBContext) : IPropiedades
    {
        /// <summary>
        /// obtenemos una conexion de la base de datos
        /// </summary>
        private readonly IMongoDBContext _mongoDBContext = mongoDBContext;

        public void ActualizarPropiedad()
        {
            throw new NotImplementedException();
        }

        public void CambiarPrecioPropiedad()
        {
            throw new NotImplementedException();
        }

        public void CargarImagenPropiedad()
        {
            throw new NotImplementedException();
        }

        public void ConsultartPropiedades()
        {
            throw new NotImplementedException();
        }

        public async Task<Propiedad> RegistrarPropiedad(RegistrarPropiedadSolicitud solicitud)
        {
            /// <summary>
            /// obtenermos la collection de la entidad Propiedades
            /// </summary>
            var coleccion = mongoDBContext.GetCollection<Propiedad>("Propiedades");


            /// <summary>
            /// Mapeamos la entidad 
            /// </summary>
            var propiedad = new Propiedad
            {                                
                Nombre = solicitud.Nombre,
                Direccion = solicitud.Direccion,
                Precio = solicitud.Precio,
                CodigoInterno = solicitud.CodigoInterno,
                anho = solicitud.anho,
                IdPropietario = solicitud.IdPropietario
            };

            /// <summary>
            /// Insertamos el objecto
            /// </summary>
            await coleccion.InsertOneAsync(propiedad);

            return propiedad;
        }
    }
}
