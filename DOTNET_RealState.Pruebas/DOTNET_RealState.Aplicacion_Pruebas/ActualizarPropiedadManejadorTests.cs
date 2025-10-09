using DOTNET_RealState.Aplicacion.CasosUso.ActualizarPropiedad;
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
    public class ActualizarPropiedadManejadorTests
    {
        private Mock<IPropiedades> _mockPropiedades;
        private ActualizarPropiedadManejador _manejador;

        [SetUp]
        public void SetUp()
        {
            _mockPropiedades = new Mock<IPropiedades>();
            _manejador = new ActualizarPropiedadManejador(_mockPropiedades.Object);
        }

        [Test]
        public async Task Handle_CuandoActualizacionEsExitosa_RetornaRespuestaExitosa()
        {
            // Arrange
            var solicitud = new ActualizarPropiedadSolicitud { IdPropiedad = "1" };
            var propiedad = new Propiedad { Id = "1", Nombre = "Casa", ano = "2025", CodigoInterno = "102", Direccion = "Kr 26 - 01",
              IdPropietario = "1", Precio = 100000};

            _mockPropiedades
                .Setup(p => p.ActualizarPropiedad(solicitud))
                .ReturnsAsync(propiedad);

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.True);
            Assert.That(respuesta.Resultado.Propiedad, Is.Not.Null);           
        }

        [Test]
        public async Task Handle_CuandoActualizacionFalla_RetornaRespuestaError()
        {
            // Arrange
            var solicitud = new ActualizarPropiedadSolicitud { IdPropiedad = "1" };

            _mockPropiedades
                .Setup(p => p.ActualizarPropiedad(solicitud))
                .ThrowsAsync(new Exception("Error de actualización"));

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
           
            Assert.That(respuesta.Mensaje.Contains("Error de actualización"), Is.True);
            Assert.That(respuesta.Resultado, Is.Not.Null);
        }
    }
}
