using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Dtos
{
    public class SolicitudRegistroPropiedadDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal Precio { get; set; }
        public string CodigoInterno { get; set; }
        public string anho { get; set; }
        public string IdPropietario { get; set; }
    }
}
