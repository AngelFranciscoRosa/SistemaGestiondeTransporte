using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransporteApp.BLL;
using Transporteapp.Entities.TransporteApp.Entities;

namespace TransporteAPP.Tests
{
    [TestClass]
    public class UsuarioIntegrationTests
    {
        [TestMethod]
        public void Login_CredencialesValidas_DebeRetornarUsuario()
        {
            // Arrange
            var service = new UsuarioService();

            string username = "admin";
            string password = "admin123";

            // Act
            var usuario = service.Login(username, password);

            // Assert
            Assert.IsNotNull(
                usuario,
                "El Login debería retornar un usuario con credenciales válidas."
            );

            Assert.AreEqual(
                6,
                usuario.IdUsuario,
                "El IdUsuario no coincide."
            );

            Assert.AreEqual(
                "admin",
                usuario.Username,
                "El Username no coincide."
            );

            Assert.AreEqual(
                "Admin",
                usuario.Rol,
                "El Rol no coincide."
            );
        }

        //test 2

        [TestMethod]
        public void Login_CredencialesInvalidas_DebeRetornarNull()
        {
            // Arrange
            var service = new UsuarioService();

            string username = "admin";
            string password = "contraseñaIncorrecta";

            // Act
            var usuario = service.Login(username, password);

            // Assert
            Assert.IsNull(
                usuario,
                "El Login debería retornar null cuando las credenciales son inválidas."
            );
        }

        //test 3

        [TestMethod]
        public void Login_UsuarioInexistente_DebeRetornarNull()
        {
            // Arrange
            var service = new UsuarioService();

            string username = "usuario_que_no_existe";
            string password = "cualquierPassword";

            // Act
            var usuario = service.Login(username, password);

            // Assert
            Assert.IsNull(
                usuario,
                "El Login debería retornar null cuando el usuario no existe."
            );
        }
    }
}