using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP.Tests
{
    [TestClass]
    public class AsignacionIntegrationTests
    {
        //test 1

        [TestMethod]
        public void GetChoferesDisponibles_DebeRetornarRegistros()
        {
            // Arrange
            var asignacionService = new AsignacionService();
            var choferService = new ChoferService();

            string cedulaPrueba =
                "TEST-" + DateTime.Now.ToString("HHmmssfff");

            var chofer = new Chofer
            {
                Nombre = "Chofer",
                Apellido = "Prueba",
                FechaNacimiento = new DateTime(1995, 1, 1),
                Cedula = cedulaPrueba
            };

            try
            {
                // Crear un chofer que no tenga ninguna asignación
                choferService.Insertar(chofer);

                // Act
                var choferes = asignacionService.GetChoferesDisponibles();

                // Buscar el chofer que acabamos de crear
                var resultado = choferes
                    .FirstOrDefault(c => c.Nombre == "Chofer");

                // Assert
                Assert.IsNotNull(
                    resultado,
                    "El chofer sin asignación debería aparecer como disponible."
                );

                Assert.IsTrue(
                    resultado.IdChofer > 0,
                    "El IdChofer debería ser mayor que cero."
                );

                Assert.AreEqual(
                    "Chofer",
                    resultado.Nombre,
                    "El nombre del chofer disponible no coincide."
                );
            }
            finally
            {
                // Cleanup
                var choferes = choferService.Listar();

                var creado = choferes
                    .FirstOrDefault(c => c.Cedula == cedulaPrueba);

                if (creado != null)
                {
                    choferService.Eliminar(creado.IdChofer);
                }
            }
        }

        //test 2

        [TestMethod]
        public void GetAutobusesDisponibles_DebeRetornarRegistros()
        {
            // Arrange
            var asignacionService = new AsignacionService();
            var autobusService = new AutobusService();

            string placaPrueba =
                "TEST-DISP-" + DateTime.Now.ToString("HHmmssfff");

            var autobus = new Autobus
            {
                Marca = "Toyota",
                Modelo = "Prueba",
                Placa = placaPrueba,
                Color = "Blanco",
                Anio = 2025
            };

            try
            {
                // Crear un autobús que no tenga ninguna asignación
                autobusService.Insertar(autobus);

                // Act
                var autobuses = asignacionService.GetAutobusesDisponibles();

                // Buscar el autobús de prueba
                var resultado = autobuses
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                // Assert
                Assert.IsNotNull(
                    resultado,
                    "El autobús sin asignación debería aparecer como disponible."
                );

                Assert.IsTrue(
                    resultado.IdAutobus > 0,
                    "El IdAutobus debería ser mayor que cero."
                );

                Assert.AreEqual(
                    placaPrueba,
                    resultado.Placa,
                    "La placa del autobús disponible no coincide."
                );
            }
            finally
            {
                // Cleanup
                var autobuses = autobusService.Listar();

                var creado = autobuses
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                if (creado != null)
                {
                    autobusService.Eliminar(creado.IdAutobus);
                }
            }
        }

        //test 3

        [TestMethod]
        public void GetRutasDisponibles_DebeRetornarRegistros()
        {
            // Arrange
            var asignacionService = new AsignacionService();
            var rutaService = new RutaService();

            string nombreRutaPrueba =
                "TEST-DISP-RUTA-" + DateTime.Now.ToString("HHmmssfff");

            var ruta = new Ruta
            {
                Nombre = nombreRutaPrueba
            };

            try
            {
                // Crear una ruta que no tenga ninguna asignación
                rutaService.Insertar(ruta);

                // Act
                var rutas = asignacionService.GetRutasDisponibles();

                // Buscar la ruta de prueba
                var resultado = rutas
                    .FirstOrDefault(r => r.Nombre == nombreRutaPrueba);

                // Assert
                Assert.IsNotNull(
                    resultado,
                    "La ruta sin asignación debería aparecer como disponible."
                );

                Assert.IsTrue(
                    resultado.IdRuta > 0,
                    "El IdRuta debería ser mayor que cero."
                );

                Assert.AreEqual(
                    nombreRutaPrueba,
                    resultado.Nombre,
                    "El nombre de la ruta disponible no coincide."
                );
            }
            finally
            {
                // Cleanup
                var rutas = rutaService.Listar();

                var creada = rutas
                    .FirstOrDefault(r => r.Nombre == nombreRutaPrueba);

                if (creada != null)
                {
                    rutaService.Eliminar(creada.IdRuta);
                }
            }
        }

        //test 4

        [TestMethod]
        public void InsertarAsignacion_DebeCrearAsignacionCorrectamente()
        {
            // Arrange
            var asignacionService = new AsignacionService();
            var choferService = new ChoferService();
            var autobusService = new AutobusService();
            var rutaService = new RutaService();

            string cedulaPrueba =
                "TEST-ASIG-" + DateTime.Now.ToString("HHmmssfff");

            string placaPrueba =
                "TEST-ASIG-" + DateTime.Now.ToString("HHmmssfff");

            string nombreRutaPrueba =
                "TEST-ASIG-RUTA-" + DateTime.Now.ToString("HHmmssfff");

            int idChofer = 0;
            int idAutobus = 0;
            int idRuta = 0;
            int idAsignacion = 0;

            var chofer = new Chofer
            {
                Nombre = "Chofer",
                Apellido = "Asignacion",
                FechaNacimiento = new DateTime(1995, 1, 1),
                Cedula = cedulaPrueba
            };

            var autobus = new Autobus
            {
                Marca = "Toyota",
                Modelo = "Prueba",
                Placa = placaPrueba,
                Color = "Blanco",
                Anio = 2025
            };

            var ruta = new Ruta
            {
                Nombre = nombreRutaPrueba
            };

            try
            {
                // Crear recursos de prueba
                choferService.Insertar(chofer);
                autobusService.Insertar(autobus);
                rutaService.Insertar(ruta);

                // Recuperar IDs
                var choferCreado = choferService.Listar()
                    .FirstOrDefault(c => c.Cedula == cedulaPrueba);

                var autobusCreado = autobusService.Listar()
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                var rutaCreada = rutaService.Listar()
                    .FirstOrDefault(r => r.Nombre == nombreRutaPrueba);

                Assert.IsNotNull(
                    choferCreado,
                    "No se encontró el chofer de prueba."
                );

                Assert.IsNotNull(
                    autobusCreado,
                    "No se encontró el autobús de prueba."
                );

                Assert.IsNotNull(
                    rutaCreada,
                    "No se encontró la ruta de prueba."
                );

                idChofer = choferCreado.IdChofer;
                idAutobus = autobusCreado.IdAutobus;
                idRuta = rutaCreada.IdRuta;

                // Crear asignación
                var asignacion = new Asignacion
                {
                    IdChofer = idChofer,
                    IdAutobus = idAutobus,
                    IdRuta = idRuta
                };

                // Act
                asignacionService.Insertar(asignacion);

                // Buscar la asignación creada
                DataTable asignaciones =
                    asignacionService.ListarAsignaciones();

                DataRow encontrada = null;

                foreach (DataRow row in asignaciones.Rows)
                {
                    string nombreRuta =
                        Convert.ToString(row["NombreRuta"]);

                    if (nombreRuta == nombreRutaPrueba)
                    {
                        encontrada = row;
                        break;
                    }
                }

                // Assert
                Assert.IsNotNull(
                    encontrada,
                    "La asignación no fue encontrada después de insertarla."
                );

                idAsignacion =
                    Convert.ToInt32(encontrada["IdAsignacion"]);

                Assert.IsTrue(
                    idAsignacion > 0,
                    "El IdAsignacion debería ser mayor que cero."
                );

                Assert.AreEqual(
                    "Chofer Asignacion",
                    Convert.ToString(encontrada["Chofer"]),
                    "El chofer de la asignación no coincide."
                );

                Assert.AreEqual(
                    "Toyota Prueba",
                    Convert.ToString(encontrada["Autobus"]),
                    "El autobús de la asignación no coincide."
                );

                Assert.AreEqual(
                    nombreRutaPrueba,
                    Convert.ToString(encontrada["NombreRuta"]),
                    "La ruta de la asignación no coincide."
                );
            }
            finally
            {
                // Eliminar asignación de prueba primero
                if (idAsignacion > 0)
                {
                    asignacionService.Eliminar(idAsignacion);
                }

                // Eliminar ruta de prueba
                if (idRuta > 0)
                {
                    rutaService.Eliminar(idRuta);
                }

                // Eliminar autobús de prueba
                if (idAutobus > 0)
                {
                    autobusService.Eliminar(idAutobus);
                }

                // Eliminar chofer de prueba
                if (idChofer > 0)
                {
                    choferService.Eliminar(idChofer);
                }
            }
        }

        //test 5

        [TestMethod]
        public void ListarAsignaciones_DebeRetornarRegistros()
        {
            // Arrange
            var service = new AsignacionService();

            // Act
            DataTable asignaciones = service.ListarAsignaciones();

            // Assert
            Assert.IsNotNull(
                asignaciones,
                "La tabla de asignaciones no debería ser null."
            );

            Assert.IsTrue(
                asignaciones.Rows.Count > 0,
                "Debería existir al menos una asignación registrada."
            );

            Assert.IsTrue(
                asignaciones.Columns.Contains("IdAsignacion"),
                "El resultado debería contener la columna IdAsignacion."
            );

            Assert.IsTrue(
                asignaciones.Columns.Contains("Chofer"),
                "El resultado debería contener la columna Chofer."
            );

            Assert.IsTrue(
                asignaciones.Columns.Contains("Autobus"),
                "El resultado debería contener la columna Autobus."
            );

            Assert.IsTrue(
                asignaciones.Columns.Contains("NombreRuta"),
                "El resultado debería contener la columna NombreRuta."
            );

            Assert.IsTrue(
                asignaciones.Columns.Contains("FechaAsignacion"),
                "El resultado debería contener la columna FechaAsignacion."
            );

            Assert.IsTrue(
                asignaciones.Columns.Contains("Activa"),
                "El resultado debería contener la columna Activa."
            );

            DataRow primeraAsignacion = asignaciones.Rows[0];

            Assert.IsTrue(
                Convert.ToInt32(primeraAsignacion["IdAsignacion"]) > 0,
                "El IdAsignacion debería ser mayor que cero."
            );

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(
                    Convert.ToString(primeraAsignacion["Chofer"])
                ),
                "El nombre del chofer no debería estar vacío."
            );

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(
                    Convert.ToString(primeraAsignacion["Autobus"])
                ),
                "El nombre del autobús no debería estar vacío."
            );

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(
                    Convert.ToString(primeraAsignacion["NombreRuta"])
                ),
                "El nombre de la ruta no debería estar vacío."
            );
        }

        //test 6

        [TestMethod]
        public void FinalizarAsignacion_DebeLiberarRecursos()
        {
            // Arrange
            var asignacionService = new AsignacionService();
            var choferService = new ChoferService();
            var autobusService = new AutobusService();
            var rutaService = new RutaService();

            string cedulaPrueba =
                "TEST-FIN-" + DateTime.Now.ToString("HHmmssfff");

            string placaPrueba =
                "TEST-FIN-" + DateTime.Now.ToString("HHmmssfff");

            string nombreRutaPrueba =
                "TEST-FIN-RUTA-" + DateTime.Now.ToString("HHmmssfff");

            int idChofer = 0;
            int idAutobus = 0;
            int idRuta = 0;
            int idAsignacion = 0;

            try
            {
                // Crear recursos de prueba
                choferService.Insertar(new Chofer
                {
                    Nombre = "Chofer",
                    Apellido = "Finalizar",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Cedula = cedulaPrueba
                });

                autobusService.Insertar(new Autobus
                {
                    Marca = "Toyota",
                    Modelo = "Finalizar",
                    Placa = placaPrueba,
                    Color = "Blanco",
                    Anio = 2025
                });

                rutaService.Insertar(new Ruta
                {
                    Nombre = nombreRutaPrueba
                });

                // Obtener IDs
                var choferCreado = choferService.Listar()
                    .FirstOrDefault(c => c.Cedula == cedulaPrueba);

                var autobusCreado = autobusService.Listar()
                    .FirstOrDefault(a => a.Placa == placaPrueba);

                var rutaCreada = rutaService.Listar()
                    .FirstOrDefault(r => r.Nombre == nombreRutaPrueba);

                Assert.IsNotNull(choferCreado);
                Assert.IsNotNull(autobusCreado);
                Assert.IsNotNull(rutaCreada);

                idChofer = choferCreado.IdChofer;
                idAutobus = autobusCreado.IdAutobus;
                idRuta = rutaCreada.IdRuta;

                // Crear asignación
                asignacionService.Insertar(new Asignacion
                {
                    IdChofer = idChofer,
                    IdAutobus = idAutobus,
                    IdRuta = idRuta
                });

                // Buscar asignación creada
                DataTable asignaciones =
                    asignacionService.ListarAsignaciones();

                foreach (DataRow row in asignaciones.Rows)
                {
                    if (Convert.ToString(row["NombreRuta"]) == nombreRutaPrueba)
                    {
                        idAsignacion =
                            Convert.ToInt32(row["IdAsignacion"]);

                        break;
                    }
                }

                Assert.IsTrue(
                    idAsignacion > 0,
                    "No se encontró la asignación de prueba."
                );

                // Act
                asignacionService.Finalizar(idAsignacion);

                // Verificar que la asignación realmente fue finalizada
                DataTable asignacionesFinalizadas =
                    asignacionService.ListarAsignaciones();

                DataRow asignacionFinalizada = null;

                foreach (DataRow row in asignacionesFinalizadas.Rows)
                {
                    if (Convert.ToInt32(row["IdAsignacion"]) == idAsignacion)
                    {
                        asignacionFinalizada = row;
                        break;
                    }
                }

                Assert.IsNotNull(
                    asignacionFinalizada,
                    "La asignación no fue encontrada después de finalizarla."
                );

                Assert.IsFalse(
                    Convert.ToBoolean(asignacionFinalizada["Activa"]),
                    "La asignación debería quedar inactiva después de finalizarla."
                );

                // Comprobar que los recursos vuelven a estar disponibles
                var choferesDisponibles =
                    asignacionService.GetChoferesDisponibles();

                var autobusesDisponibles =
                    asignacionService.GetAutobusesDisponibles();

                var rutasDisponibles =
                    asignacionService.GetRutasDisponibles();

                // Assert
                Assert.IsTrue(
                    choferesDisponibles.Any(c =>
                        c.IdChofer == idChofer),
                    "El chofer debería volver a estar disponible."
                );

                Assert.IsTrue(
                    autobusesDisponibles.Any(a =>
                        a.IdAutobus == idAutobus),
                    "El autobús debería volver a estar disponible."
                );

                Assert.IsTrue(
                    rutasDisponibles.Any(r =>
                        r.IdRuta == idRuta),
                    "La ruta debería volver a estar disponible."
                );
            }
            finally
            {
                // Eliminar asignación de prueba
                if (idAsignacion > 0)
                {
                    asignacionService.Eliminar(idAsignacion);
                }

                // Eliminar ruta
                if (idRuta > 0)
                {
                    rutaService.Eliminar(idRuta);
                }

                // Eliminar autobús
                if (idAutobus > 0)
                {
                    autobusService.Eliminar(idAutobus);
                }

                // Eliminar chofer
                if (idChofer > 0)
                {
                    choferService.Eliminar(idChofer);
                }
            }
        }
    }
}