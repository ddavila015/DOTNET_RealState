using DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
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

        void ConsultartPropiedades(ConsultarPropiedadSolicitud solicitud);

        void ActualizarPropiedad();

        void CambiarPrecioPropiedad();

        void CargarImagenPropiedad();
    }
}
