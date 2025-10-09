using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.CambiarPrecioPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.CargarImagenPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.Dtos;
using DOTNET_RealState.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Puertos
{
    public interface IPropiedades
    {

        Task<Propiedad> RegistrarPropiedad(RegistrarPropiedadSolicitud solicitud);

        List<PropiedadDTO> ConsultartPropiedades(ConsultarPropiedadSolicitud solicitud);

        Task<Propiedad> ActualizarPropiedad(ActualizarPropiedadSolicitud solicitud);

        Task<Propiedad> CambiarPrecioPropiedad(CambiarPrecioPropiedadSolicitud solicitud);

        Task<ImagenPropiedad> CargarImagenPropiedad(CargarImagenPropiedadSolicitud solicitud);
    }
}
