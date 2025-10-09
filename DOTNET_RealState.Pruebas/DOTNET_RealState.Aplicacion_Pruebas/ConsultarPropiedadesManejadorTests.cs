using DOTNET_RealState.Aplicacion.CasosUso.ConsultarPropiedad;
using DOTNET_RealState.Aplicacion.Dtos;
using DOTNET_RealState.Aplicacion.Puertos;
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
    public class ConsultarPropiedadesManejadorTests
    {
        private Mock<IPropiedades> _mockPropiedades;
        private ConsultarPropiedadesManejador _manejador;

        [SetUp]
        public void SetUp()
        {
            _mockPropiedades = new Mock<IPropiedades>();
            _manejador = new ConsultarPropiedadesManejador(_mockPropiedades.Object);
        }

        [Test]
        public async Task Handle_CuandoConsultaEsExitosa_RetornaRespuestaExitosa()
        {
            // Arrange
            var solicitud = new ConsultarPropiedadSolicitud();
            var lista = new List<PropiedadDTO>
            {
                new PropiedadDTO { Id = "1", Nombre = "Casa 1" },
                new PropiedadDTO { Id = "2", Nombre = "Casa 2" }
            };

            _mockPropiedades
                .Setup(p => p.ConsultartPropiedades(solicitud))
                .Returns(lista);

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.True);
            Assert.That(respuesta.Resultado.Propiedades, Is.Not.Null);         
        }

        [Test]
        public async Task Handle_CuandoConsultaFalla_RetornaRespuestaError()
        {
            // Arrange
            var solicitud = new ConsultarPropiedadSolicitud();

            _mockPropiedades
                .Setup(p => p.ConsultartPropiedades(solicitud))
                .Throws(new Exception("Error de consulta"));

            // Act
            var respuesta = await _manejador.Handle(solicitud, CancellationToken.None);

            // Assert
            Assert.That(respuesta.OperacionExitosa, Is.False);
            Assert.That(respuesta.Mensaje.Contains("Error de consulta"), Is.True);
            Assert.That(respuesta.Resultado, Is.Not.Null);
        }
    }
}
