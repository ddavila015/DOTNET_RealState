using DOTNET_RealState.Aplicacion.CasosUso.RegistrarUsuario;
using DOTNET_RealState.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Puertos
{
    public interface IUsuarios
    {
        Task<Usuario> RegistrarUsuarios(RegistrarUsuarioSolicitud solicitud);
    }
}
