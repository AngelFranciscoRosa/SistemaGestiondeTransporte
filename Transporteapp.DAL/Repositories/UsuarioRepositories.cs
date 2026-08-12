using System.Data;
using System.Data.SqlClient;
using Transporteapp.Entities.TransporteApp.Entities;
using TransporteApp.DAL.Connection;

namespace TransporteApp.DAL.Repositories
{
    public class UsuarioRepository
    {
        public Usuario Login(string username, string password)
        {
            var db = new DbConnection(); // o ConexionDB si lo cambiaste

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = (int)reader["IdUsuario"],
                            Username = reader["Username"].ToString(),
                            Rol = reader["Rol"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}