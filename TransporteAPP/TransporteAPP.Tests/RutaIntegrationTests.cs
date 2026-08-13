using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP.Tests
{
    [TestClass]
    public class RutaIntegrationTests
    {
        //test 1
        [TestMethod]
        public void InsertarRuta_DebeGuardarseCorrectamente()
        {
            // Arrange
            var service = new RutaService();

            string nombreRuta = "TEST-RUTA-" + DateTime.Now.ToString("HHmmssfff");

            var ruta = new Ruta
            {
                Nombre = nombreRuta
            };

            try
            {
                // Act
                service.Insertar(ruta);

                // Consultar nuevamente desde SQL Server
                var rutas = service.Listar();

                var resultado = rutas
                    .FirstOrDefault(r => r.Nombre == nombreRuta);

                // Assert
                Assert.IsNotNull(
                    resultado,
                    "La ruta fue insertada, pero no fue encontrada al consultar la base de datos."
                );

                Assert.AreEqual(
                    nombreRuta,
                    resultado.Nombre,
                    "El nombre de la ruta no coincide."
                );
            }
            finally
            {
                // Cleanup
                var rutas = service.Listar();

                var creada = rutas
                    .FirstOrDefault(r => r.Nombre == nombreRuta);

                if (creada != null)
                {
                    service.Eliminar(creada.IdRuta);
                }
            }
        }

        //test 2
        [TestMethod]
        public void ListarRutas_DebeRetornarRegistros()
        {
            // Arrange
            var service = new RutaService();

            // Act
            var rutas = service.Listar();

            // Assert
            Assert.IsNotNull(
                rutas,
                "La lista de rutas no debería ser null."
            );

            Assert.IsTrue(
                rutas.Count > 0,
                "La base de datos debería contener al menos una ruta."
            );

            var primeraRuta = rutas.First();

            Assert.IsTrue(
                primeraRuta.IdRuta > 0,
                "El IdRuta debería ser mayor que cero."
            );

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(primeraRuta.Nombre),
                "El nombre de la ruta no debería estar vacío."
            );
        }

        //test 3
        [TestMethod]
        public void ActualizarRuta_DebeModificarDatos()
        {
            // Arrange
            var service = new RutaService();

            string nombreRutaOriginal =
                "TEST-RUTA-UPD-" + DateTime.Now.ToString("HHmmssfff");

            string nombreRutaActualizada =
                nombreRutaOriginal + "-ACTUALIZADA";

            var ruta = new Ruta
            {
                Nombre = nombreRutaOriginal
            };

            try
            {
                // Crear ruta de prueba
                service.Insertar(ruta);

                // Recuperar el ID generado por SQL Server
                var rutaCreada = service.Listar()
                    .FirstOrDefault(r => r.Nombre == nombreRutaOriginal);

                Assert.IsNotNull(
                    rutaCreada,
                    "No se encontró la ruta creada para realizar la actualización."
                );

                // Act
                rutaCreada.Nombre = nombreRutaActualizada;

                service.Actualizar(rutaCreada);

                // Consultar nuevamente
                var rutaActualizada = service.Listar()
                    .FirstOrDefault(r => r.IdRuta == rutaCreada.IdRuta);

                // Assert
                Assert.IsNotNull(
                    rutaActualizada,
                    "La ruta actualizada no fue encontrada."
                );

                Assert.AreEqual(
                    nombreRutaActualizada,
                    rutaActualizada.Nombre,
                    "El nombre de la ruta no fue actualizado correctamente."
                );
            }
            finally
            {
                // Cleanup
                var rutas = service.Listar();

                var rutaCreada = rutas
                    .FirstOrDefault(r =>
                        r.Nombre == nombreRutaOriginal ||
                        r.Nombre == nombreRutaActualizada);

                if (rutaCreada != null)
                {
                    service.Eliminar(rutaCreada.IdRuta);
                }
            }
        }

        //test 4
        [TestMethod]
        public void EliminarRuta_DebeEliminarRegistro()
        {
            // Arrange
            var service = new RutaService();

            string nombreRuta =
                "TEST-RUTA-DEL-" + DateTime.Now.ToString("HHmmssfff");

            var ruta = new Ruta
            {
                Nombre = nombreRuta
            };

            // Crear ruta de prueba
            service.Insertar(ruta);

            // Obtener el ID generado
            var rutaCreada = service.Listar()
                .FirstOrDefault(r => r.Nombre == nombreRuta);

            Assert.IsNotNull(
                rutaCreada,
                "No se encontró la ruta creada para realizar la eliminación."
            );

            // Act
            service.Eliminar(rutaCreada.IdRuta);

            // Consultar nuevamente
            var rutaEliminada = service.Listar()
                .FirstOrDefault(r => r.IdRuta == rutaCreada.IdRuta);

            // Assert
            Assert.IsNull(
                rutaEliminada,
                "La ruta todavía aparece como activa después de eliminarla."
            );
        }
    }
}