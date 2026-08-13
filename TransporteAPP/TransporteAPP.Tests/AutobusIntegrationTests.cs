using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP.Tests
{
    [TestClass]
    public class AutobusIntegrationTests
    {
        //test 1
        [TestMethod]
        public void InsertarAutobus_DebeGuardarseCorrectamente()
        {
            // Arrange
            var service = new AutobusService();

            string placaPrueba = "TEST-" + DateTime.Now.ToString("HHmmssfff");

            var autobus = new Autobus
            {
                Marca = "Toyota",
                Modelo = "Coaster",
                Placa = placaPrueba,
                Color = "Blanco",
                Anio = 2024
            };

            try
            {
                // Act
                service.Insertar(autobus);

                // Consultar nuevamente desde SQL Server
                var autobuses = service.Listar();

                var resultado = autobuses
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                // Assert
                Assert.IsNotNull(
                    resultado,
                    "El autobús fue insertado, pero no fue encontrado al consultar la base de datos."
                );

                Assert.AreEqual(
                    "Toyota",
                    resultado.Marca,
                    "La marca del autobús no coincide."
                );

                Assert.AreEqual(
                    "Coaster",
                    resultado.Modelo,
                    "El modelo del autobús no coincide."
                );

                Assert.AreEqual(
                    "Blanco",
                    resultado.Color,
                    "El color del autobús no coincide."
                );

                Assert.AreEqual(
                    2024,
                    resultado.Anio,
                    "El año del autobús no coincide."
                );
            }
            finally
            {
                // Cleanup
                var autobuses = service.Listar();

                var creado = autobuses
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                if (creado != null)
                {
                    service.Eliminar(creado.IdAutobus);
                }
            }
        }

        //test 2
        [TestMethod]
        public void ListarAutobuses_DebeRetornarRegistros()
        {
            // Arrange
            var service = new AutobusService();

            // Act
            var autobuses = service.Listar();

            // Assert
            Assert.IsNotNull(
                autobuses,
                "La lista de autobuses no debería ser null."
            );

            Assert.IsTrue(
                autobuses.Count > 0,
                "La base de datos debería contener al menos un autobús."
            );

            var primerAutobus = autobuses.First();

            Assert.IsTrue(
                primerAutobus.IdAutobus > 0,
                "El IdAutobus debería ser mayor que cero."
            );

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(primerAutobus.Marca),
                "La marca del autobús no debería estar vacía."
            );

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(primerAutobus.Placa),
                "La placa del autobús no debería estar vacía."
            );
        }

        //test 3
        [TestMethod]
        public void ActualizarAutobus_DebeModificarDatos()
        {
            // Arrange
            var service = new AutobusService();

            string placaPrueba = "TEST-UPD-" + DateTime.Now.ToString("HHmmssfff");

            var autobus = new Autobus
            {
                Marca = "Toyota",
                Modelo = "Coaster",
                Placa = placaPrueba,
                Color = "Blanco",
                Anio = 2024
            };

            try
            {
                // Crear registro de prueba
                service.Insertar(autobus);

                // Recuperar el ID generado por SQL Server
                var autobusCreado = service.Listar()
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                Assert.IsNotNull(
                    autobusCreado,
                    "No se encontró el autobús creado para realizar la actualización."
                );

                // Act - modificar datos
                autobusCreado.Marca = "Mercedes-Benz";
                autobusCreado.Modelo = "Sprinter";
                autobusCreado.Color = "Azul";
                autobusCreado.Anio = 2025;

                service.Actualizar(autobusCreado);

                // Consultar nuevamente
                var autobusActualizado = service.Listar()
                    .FirstOrDefault(a => a.IdAutobus == autobusCreado.IdAutobus);

                // Assert
                Assert.IsNotNull(
                    autobusActualizado,
                    "El autobús actualizado no fue encontrado."
                );

                Assert.AreEqual(
                    "Mercedes-Benz",
                    autobusActualizado.Marca,
                    "La marca no fue actualizada correctamente."
                );

                Assert.AreEqual(
                    "Sprinter",
                    autobusActualizado.Modelo,
                    "El modelo no fue actualizado correctamente."
                );

                Assert.AreEqual(
                    "Azul",
                    autobusActualizado.Color,
                    "El color no fue actualizado correctamente."
                );

                Assert.AreEqual(
                    2025,
                    autobusActualizado.Anio,
                    "El año no fue actualizado correctamente."
                );
            }
            finally
            {
                // Cleanup
                var autobuses = service.Listar();

                var creado = autobuses
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                if (creado != null)
                {
                    service.Eliminar(creado.IdAutobus);
                }
            }
        }

        //test 4
        [TestMethod]
        public void EliminarAutobus_DebeEliminarRegistro()
        {
            // Arrange
            var service = new AutobusService();

            string placaPrueba = "TEST-DEL-" + DateTime.Now.ToString("HHmmssfff");

            var autobus = new Autobus
            {
                Marca = "Toyota",
                Modelo = "Prueba",
                Placa = placaPrueba,
                Color = "Negro",
                Anio = 2024
            };

            // Crear registro de prueba
            service.Insertar(autobus);

            // Recuperar el ID generado por SQL Server
            var autobusCreado = service.Listar()
                .FirstOrDefault(a => a.Placa == placaPrueba);

            Assert.IsNotNull(
                autobusCreado,
                "No se encontró el autobús creado para realizar la eliminación."
            );

            // Act
            service.Eliminar(autobusCreado.IdAutobus);

            // Consultar nuevamente
            var autobusEliminado = service.Listar()
                .FirstOrDefault(a => a.IdAutobus == autobusCreado.IdAutobus);

            // Assert
            Assert.IsNull(
                autobusEliminado,
                "El autobús todavía existe después de ejecutar la eliminación."
            );
        }
    }
}