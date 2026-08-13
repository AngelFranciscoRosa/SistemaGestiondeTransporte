using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP.Tests
{
    [TestClass]
    public class ChoferIntegrationTests
    {
        [TestMethod]
        public void InsertarChofer_DebeGuardarseCorrectamente()
        {
            // Arrange
            var service = new ChoferService();

            string cedulaPrueba = "TEST-" + DateTime.Now.ToString("HHmmssfff");

            var chofer = new Chofer
            {
                Nombre = "ChoferTest",
                Apellido = "Automatizado",
                FechaNacimiento = new DateTime(1995, 5, 15),
                Cedula = cedulaPrueba
            };

            try
            {
                // Act
                service.Insertar(chofer);

                // Consultamos nuevamente la información desde SQL Server
                var choferes = service.Listar();

                var resultado = choferes
                    .FirstOrDefault(c => c.Cedula == cedulaPrueba);

                // Assert
                Assert.IsNotNull(
                    resultado,
                    "El chofer fue insertado, pero no fue encontrado al consultar la base de datos."
                );

                Assert.AreEqual(
                    "ChoferTest",
                    resultado.Nombre,
                    "El nombre del chofer no coincide."
                );

                Assert.AreEqual(
                    "Automatizado",
                    resultado.Apellido,
                    "El apellido del chofer no coincide."
                );
            }
            finally
            {
                // Cleanup
                var choferes = service.Listar();

                var creado = choferes
                    .FirstOrDefault(c => c.Cedula == cedulaPrueba);

                if (creado != null)
                {
                    service.Eliminar(creado.IdChofer);
                }
            }
        }

        //Test 2 — Listar choferes

        [TestMethod]
        public void ListarChoferes_DebeRetornarRegistros()
        {
            // Arrange
            var service = new ChoferService();

            // Act
            var choferes = service.Listar();

            // Assert
            Assert.IsNotNull(
                choferes,
                "La lista de choferes no debería ser null."
            );

            Assert.IsTrue(
                choferes.Count > 0,
                "La base de datos debería contener al menos un chofer."
            );

            var primerChofer = choferes.First();

            Assert.IsTrue(
                primerChofer.IdChofer > 0,
                "El IdChofer debería ser mayor que cero."
            );

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(primerChofer.Nombre),
                "El nombre del chofer no debería estar vacío."
            );
        }

        //test 3 -actualizar
        [TestMethod]
        public void ActualizarChofer_DebeModificarDatos()
        {
            // Arrange
            var service = new ChoferService();

            string cedulaPrueba = "TEST-UPD-" + DateTime.Now.ToString("HHmmssfff");

            var chofer = new Chofer
            {
                Nombre = "ChoferOriginal",
                Apellido = "ApellidoOriginal",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Cedula = cedulaPrueba
            };

            try
            {
                // Crear registro de prueba
                service.Insertar(chofer);

                // Recuperar el registro recién creado
                var choferCreado = service.Listar()
                    .FirstOrDefault(c => c.Cedula == cedulaPrueba);

                Assert.IsNotNull(
                    choferCreado,
                    "No se encontró el chofer creado para realizar la actualización."
                );

                // Act - modificar datos
                choferCreado.Nombre = "ChoferModificado";
                choferCreado.Apellido = "ApellidoModificado";
                choferCreado.FechaNacimiento = new DateTime(1992, 10, 20);

                service.Actualizar(choferCreado);

                // Consultar nuevamente
                var choferActualizado = service.Listar()
                    .FirstOrDefault(c => c.IdChofer == choferCreado.IdChofer);

                // Assert
                Assert.IsNotNull(
                    choferActualizado,
                    "El chofer actualizado no fue encontrado."
                );

                Assert.AreEqual(
                    "ChoferModificado",
                    choferActualizado.Nombre,
                    "El nombre no fue actualizado correctamente."
                );

                Assert.AreEqual(
                    "ApellidoModificado",
                    choferActualizado.Apellido,
                    "El apellido no fue actualizado correctamente."
                );

                Assert.AreEqual(
                    new DateTime(1992, 10, 20),
                    choferActualizado.FechaNacimiento,
                    "La fecha de nacimiento no fue actualizada correctamente."
                );
            }
            finally
            {
                // Cleanup
                var choferes = service.Listar();

                var creado = choferes
                    .FirstOrDefault(c => c.Cedula == cedulaPrueba);

                if (creado != null)
                {
                    service.Eliminar(creado.IdChofer);
                }
            }
        }

        //test 4 -Eliminar

        [TestMethod]
        public void EliminarChofer_DebeEliminarRegistro()
        {
            // Arrange
            var service = new ChoferService();

            string cedulaPrueba = "TEST-DEL-" + DateTime.Now.ToString("HHmmssfff");

            var chofer = new Chofer
            {
                Nombre = "ChoferEliminar",
                Apellido = "Prueba",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Cedula = cedulaPrueba
            };

            // Crear registro de prueba
            service.Insertar(chofer);

            // Recuperar el ID generado por SQL Server
            var choferCreado = service.Listar()
                .FirstOrDefault(c => c.Cedula == cedulaPrueba);

            Assert.IsNotNull(
                choferCreado,
                "No se encontró el chofer creado para realizar la eliminación."
            );

            // Act
            service.Eliminar(choferCreado.IdChofer);

            // Consultar nuevamente
            var choferEliminado = service.Listar()
                .FirstOrDefault(c => c.IdChofer == choferCreado.IdChofer);

            // Assert
            Assert.IsNull(
                choferEliminado,
                "El chofer todavía existe después de ejecutar la eliminación."
            );
        }



    }


}

