using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
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
    public class Propiedades : IPropiedades
    {
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

        public async void RegistrarPropiedad(RegistrarPropiedadSolicitud solicitud)
        {

            // Conexión a MongoDB (ajusta la cadena según tu entorno)
            var cliente = new MongoClient("mongodb://localhost:27017");
            var database = cliente.GetDatabase("RealEstateBD");
            var coleccion = database.GetCollection<Propiedad>("Propiedades");
            var sequenceGenerator = new SequenceGenerator();


            // Objeto a insertar
            var propiedad = new Propiedad
            {                                
                Nombre = solicitud.Nombre,
                Direccion = solicitud.Direccion,
                Precio = solicitud.Precio,
                CodigoInterno = solicitud.CodigoInterno,
                anho = solicitud.anho,
                IdPropietario = solicitud.IdPropietario
            };

            // Insertar en la colección
            await coleccion.InsertOneAsync(propiedad);

            Console.WriteLine("Propiedad insertada con Id generado: " + propiedad.Id);
        }
    }
}
