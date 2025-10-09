using DOTNET_RealState.Aplicacion.CasosUso.CargarImagenPropiedad;
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
    public class CargarImagenPropiedadManejadorTests
    {
        private Mock<IPropiedades> _mockPropiedades;
        private CargarImagenPropiedadManejador _manejador;

        [SetUp]
        public void SetUp()
        {
            _mockPropiedades = new Mock<IPropiedades>();
            _manejador = new CargarImagenPropiedadManejador(_mockPropiedades.Object);
        }

        [Test]
        public async Task Handle_CuandoCargaEsExitosa_RetornaRespuestaExitosa()
        {
            // Arrange
            var solicitud = new CargarImagenPropiedadSolicitud { IdPropiedad = "1", ImgBase64 = "base64", ArchivoNombre = "foto.jpg" };
            var imagen = new ImagenPropiedad { IdPropiedad = "1", ImgBase64 = "base64", ArchivoNombre = "foto.jpg", Activo = true };

            _mockPropiedades
                .Setup(p => p.CargarImagenPropiedad(solicitud))
                .ReturnsAsync(imagen);

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.True);
            Assert.That(respuesta.Resultado.ImagenPropiedad, Is.Not.Null);           
        }

        [Test]
        public async Task Handle_CuandoCargaFalla_RetornaRespuestaError()
        {
            // Arrange
            var solicitud = new CargarImagenPropiedadSolicitud { IdPropiedad = "1", ImgBase64 = "base64", ArchivoNombre = "foto.jpg" };

            _mockPropiedades
                .Setup(p => p.CargarImagenPropiedad(solicitud))
                .ThrowsAsync(new Exception("Error al cargar imagen"));

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.False);
            Assert.That(respuesta.Mensaje.Contains("Error al cargar imagen"), Is.True);
            Assert.That(respuesta.OperacionExitosa, Is.Not.Null);
        }
    }
}
