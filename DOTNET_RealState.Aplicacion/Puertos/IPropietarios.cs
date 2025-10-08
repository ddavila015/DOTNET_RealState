using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropietario;
using DOTNET_RealState.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Puertos
{
    public interface IPropietarios
    {
        Task<Propietario> RegistrarPropietario(RegistrarPropietarioSolicitud solicitud);
    }
}
