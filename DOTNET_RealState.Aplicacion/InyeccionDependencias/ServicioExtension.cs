using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.InyeccionDependencias
{
    public static class ServicioExtension
    {
        public static void AgregarCapaAplicacion(this IServiceCollection servicios)
        {
            servicios.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
