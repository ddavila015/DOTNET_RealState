using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Dominio.Entidades
{
    public class DetallePropiedad
    {
        public string IdDetallePropiedad { get; set; }
        public string FechaVenta { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public string Impuesto { get; set; }
        public string IdPropiedad { get; set; }
    }
}
