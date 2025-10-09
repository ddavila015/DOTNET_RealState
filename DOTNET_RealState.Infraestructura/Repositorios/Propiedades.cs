using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.CambiarPrecioPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.CargarImagenPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Dtos;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
using DOTNET_RealState.Infraestructura.Persistencia;
using MongoDB.Bson;
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

        public async Task<Propiedad> ActualizarPropiedad(ActualizarPropiedadSolicitud solicitud)
        {
            try
            { 
                /// <summary>
                /// obtenermos la collection de la entidad Propiedades
                /// </summary>
                var coleccion = _mongoDBContext.GetCollection<Propiedad>("Propiedades");

                /// <summary>
                /// Filtramos por el Id de la propiedad
                /// </summary>
                var filtro = Builders<Propiedad>.Filter.Eq(x => x.Id, solicitud.IdPropiedad);

                /// <summary>
                /// Validar si la Propiedad existe
                /// </summary>
                 var propiedadExistente = await coleccion.Find(filtro).FirstOrDefaultAsync();
                if (propiedadExistente == null)
                {
                    throw new Exception("La Propiedad no se encuentra registrada.");
                }



                /// <summary>
                /// obtenermos la collection de la entidad Propietario
                /// </summary>
                var coleccionPropietario = _mongoDBContext.GetCollection<Propietario>("Propietarios");

                /// <summary>
                /// Filtramos por el Id de la Propietario
                /// </summary>
                var filtroPropietario = Builders<Propietario>.Filter.Eq(x => x.Id, solicitud.IdPropietario);
             
                /// <summary>
                /// Validar si encuentra el propietario
                /// </summary>
                var propietarioExistente = await coleccionPropietario.Find(filtroPropietario).FirstOrDefaultAsync();
                if (propietarioExistente == null)
                {
                    throw new Exception("El propietario no se encuentra registrado.");
                }
             

                /// <summary>
                /// Mapeamos los parametros de la Propiedad
                /// </summary>           
                propiedadExistente.Nombre = solicitud.Nombre;
                propiedadExistente.Direccion = solicitud.Direccion;
                propiedadExistente.Precio = solicitud.Precio;
                propiedadExistente.CodigoInterno = solicitud.CodigoInterno;
                propiedadExistente.ano = solicitud.ano;
                propiedadExistente.IdPropietario = solicitud.IdPropietario;
  
                /// <summary>
                /// Insertamos el objecto
                /// </summary>
                await coleccion.ReplaceOneAsync(filtro, propiedadExistente);

                return propiedadExistente;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }
        }

        public async Task<Propiedad> CambiarPrecioPropiedad(CambiarPrecioPropiedadSolicitud solicitud)
        {
            try
            {
                /// <summary>
                /// obtenermos la collection de la entidad Propiedades
                /// </summary>
                var coleccion = _mongoDBContext.GetCollection<Propiedad>("Propiedades");


                /// <summary>
                /// Filtramos por el Id de la propiedad
                /// </summary>
                var filtro = Builders<Propiedad>.Filter.Eq(x => x.Id, solicitud.IdPropiedad);


                /// <summary>
                /// Validar si encuentra el registro
                /// </summary>
                var propiedadExistente = await coleccion.Find(filtro).FirstOrDefaultAsync();


                if (propiedadExistente != null)
                {
                    /// <summary>
                    /// Mapeamos solo el precio
                    /// </summary>           
                    propiedadExistente.Precio = solicitud.Precio;

                    /// <summary>
                    /// Insertamos el objecto
                    /// </summary>
                    await coleccion.ReplaceOneAsync(filtro, propiedadExistente);

                    return propiedadExistente;
                }
                else
                {
                    throw new Exception("La Propiedad no se encuentra registrada.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }
        }

        public async Task<ImagenPropiedad> CargarImagenPropiedad(CargarImagenPropiedadSolicitud solicitud)
        {
            try
            {
                /// <summary>
                /// obtenermos la collection de la entidad Propiedades
                /// </summary>
                var coleccion = _mongoDBContext.GetCollection<ImagenPropiedad>("ImagenPropiedad");

                /// <summary>
                /// Mapeamos la entidad de ImagenPropiedad
                /// </summary>
                var imagenPropiedad = new ImagenPropiedad
                {
                    IdPropiedad = solicitud.IdPropiedad,
                    ImgBase64 = solicitud.ImgBase64,
                    ArchivoNombre = solicitud.ArchivoNombre,
                    Activo = true         
                };

                /// <summary>
                /// Insertamos el objecto
                /// </summary>
                await coleccion.InsertOneAsync(imagenPropiedad);


                /// <summary>
                /// Retornamos la objecto
                /// </summary>
                return imagenPropiedad;

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }
        }

        public List<PropiedadDTO> ConsultartPropiedades(ConsultarPropiedadSolicitud solicitud)
        {
            try
            {
                /// <summary>
                /// obtenermos la collection de la entidad Propiedades
                /// </summary>          
                var resultado = _mongoDBContext.GetCollection<Propiedad>("Propiedades")
                             .Aggregate()
                             .Lookup(
                                 foreignCollectionName: "Propietarios",
                                 localField: "IdPropietario",
                                 foreignField: "_id",
                                 @as: "Propietario"
                             )
                             .Unwind("Propietario", new AggregateUnwindOptions<PropietarioDTO>
                             {
                                 PreserveNullAndEmptyArrays = true
                             })
                             .Lookup(
                                 foreignCollectionName: "ImagenPropiedad",
                                 localField: "Id",
                                 foreignField: "IdPropiedad",
                                 @as: "Imagenes"
                             ).As<PropiedadDTO>();




                             if (solicitud.PrecioMaximo != null && solicitud.PrecioMaximo != 0)
                             {
                                 resultado = resultado.Match(x => x.Precio <= solicitud.PrecioMaximo);
                             }
                      

                            // Filtro por propietario (si viene en la solicitud)
                            if (solicitud.ano != null && solicitud.ano != "")
                            {
                                resultado = resultado.Match(Builders<PropiedadDTO>.Filter.Eq(x => x.ano, solicitud.ano));
                            } 

                return resultado.As<PropiedadDTO>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }
        }

        public async Task<Propiedad> RegistrarPropiedad(RegistrarPropiedadSolicitud solicitud)
        {
            try
            {                       
                /// <summary>
                /// obtenermos la collection de la entidad Propietario
                /// </summary>
                var coleccionPropietario = _mongoDBContext.GetCollection<Propietario>("Propietarios");

                /// <summary>
                /// Filtramos por el Id de la Propietario
                /// </summary>
                var filtroPropietario = Builders<Propietario>.Filter.Eq(x => x.Id, solicitud.IdPropietario);

                /// <summary>
                /// Validar si encuentra el propietario
                /// </summary>
                var propietarioExistente = await coleccionPropietario.Find(filtroPropietario).FirstOrDefaultAsync();
                if (propietarioExistente == null)
                {
                    throw new Exception("El Propietario no se encuentra registrado.");
                }


                /// <summary>
                /// obtenermos la collection de la entidad Propiedades
                /// </summary>
                var coleccion = _mongoDBContext.GetCollection<Propiedad>("Propiedades");

                /// <summary>
                /// Mapeamos la entidad 
                /// </summary>
                var propiedad = new Propiedad
                {                                
                    Nombre = solicitud.Nombre,
                    Direccion = solicitud.Direccion,
                    Precio = solicitud.Precio,
                    CodigoInterno = solicitud.CodigoInterno,
                    ano = solicitud.ano,
                    IdPropietario = solicitud.IdPropietario
                };

                /// <summary>
                /// Insertamos el objecto
                /// </summary>
                await coleccion.InsertOneAsync(propiedad);

                return propiedad;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}
