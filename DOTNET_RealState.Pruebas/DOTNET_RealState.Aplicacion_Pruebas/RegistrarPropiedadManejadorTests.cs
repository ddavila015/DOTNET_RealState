using DOTNET_RealState.Aplicacion.CasosUso.Propiedades;
using DOTNET_RealState.Aplicacion.CasosUso.RegistrarPropiedad;
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
    public class RegistrarPropiedadManejadorTests
    {
        private Mock<IPropiedades> _mockPropiedades;
        private RegistrarPropiedadManejador _manejador;

        [SetUp]
        public void SetUp()
        {
            _mockPropiedades = new Mock<IPropiedades>();
            _manejador = new RegistrarPropiedadManejador(_mockPropiedades.Object);
        }

        [Test]
        public async Task Handle_CuandoRegistroEsExitoso_RetornaRespuestaExitosa()
        {
            // Arrange
            var solicitud = new RegistrarPropiedadSolicitud { Nombre = "Casa", Direccion = "Calle 1", Precio = 1000, CodigoInterno = "A1", ano = "2023", IdPropietario = "P1" };
            var propiedad = new Propiedad { Nombre = "Casa", Direccion = "Calle 1", Precio = 1000, CodigoInterno = "A1", ano = "2023", IdPropietario = "P1" };

            _mockPropiedades
                .Setup(p => p.RegistrarPropiedad(solicitud))
                .ReturnsAsync(propiedad);

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.True);
            Assert.That(respuesta.Resultado.Propiedad,Is.Not.Null);          
        }

        [Test]
        public async Task Handle_CuandoRegistroFalla_RetornaRespuestaError()
        {
            // Arrange
            var solicitud = new RegistrarPropiedadSolicitud { Nombre = "Casa", Direccion = "Calle 1", Precio = 1000, CodigoInterno = "A1", ano = "2023", IdPropietario = "P1" };

            _mockPropiedades
                .Setup(p => p.RegistrarPropiedad(solicitud))
                .ThrowsAsync(new Exception("Error al registrar propiedad"));

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.False);
            Assert.That(respuesta.Mensaje.Contains("Error al registrar propiedad"), Is.True);
            Assert.That(respuesta.Resultado, Is.Not.Null);
        }
    }
}
