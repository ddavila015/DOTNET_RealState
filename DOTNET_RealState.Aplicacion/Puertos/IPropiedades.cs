using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Puertos
{
    public interface IPropiedades
    {

        void RegistrarPropiedad(RegistrarPropiedadSolicitud solicitud);

        void ConsultartPropiedades();

        void ActualizarPropiedad();

        void CambiarPrecioPropiedad();

        void CargarImagenPropiedad();
    }
}
