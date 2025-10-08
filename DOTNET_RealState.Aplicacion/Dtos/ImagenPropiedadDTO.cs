using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Aplicacion.Dtos
{
    public class ImagenPropiedadDTO
    {
        public string Id { get; set; }
        public string IdPropiedad { get; set; }
        public string ArchivoNombre { get; set; }
        public string ImgBase64 { get; set; }
        public bool Activo { get; set; }
    }
}
