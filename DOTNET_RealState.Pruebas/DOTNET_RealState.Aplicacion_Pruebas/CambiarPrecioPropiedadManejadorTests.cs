using DOTNET_RealState.Aplicacion.CasosUso.CambiarPrecioPropiedad;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Dominio.Entidades;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_RealState.Pruebas.DOTNET_RealState.Aplicacion_Pruebas
{
    [TestFixture]
    public class CambiarPrecioPropiedadManejadorTests
    {
        private Mock<IPropiedades> _mockPropiedades;
        private CambiarPrecioPropiedadManejador _manejador;

        [SetUp]
        public void SetUp()
        {
            _mockPropiedades = new Mock<IPropiedades>();
            _manejador = new CambiarPrecioPropiedadManejador(_mockPropiedades.Object);
        }

        [Test]
        public async Task Handle_CuandoCambioEsExitoso_RetornaRespuestaExitosa()
        {
            // Arrange
            var solicitud = new CambiarPrecioPropiedadSolicitud { IdPropiedad = "1", Precio = 2000 };
            var propiedad = new Propiedad { Id = "1", Precio = 2000 };

            _mockPropiedades
                .Setup(p => p.CambiarPrecioPropiedad(solicitud))
                .ReturnsAsync(propiedad);

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.True);
            Assert.That(respuesta.Resultado.Propiedad, Is.Not.Null);           
        }

        [Test]
        public async Task Handle_CuandoCambioFalla_RetornaRespuestaError()
        {
            // Arrange
            var solicitud = new CambiarPrecioPropiedadSolicitud { IdPropiedad = "1", Precio = 2000 };

            _mockPropiedades
                .Setup(p => p.CambiarPrecioPropiedad(solicitud))
                .ThrowsAsync(new Exception("No se pudo cambiar el precio"));

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.ByVal(respuesta.OperacionExitosa, Is.False);
            Assert.That(respuesta.Mensaje.Contains("No se pudo cambiar el precio"), Is.True);
            Assert.That(respuesta.Resultado, Is.Not.Null);
        }
    }
}
