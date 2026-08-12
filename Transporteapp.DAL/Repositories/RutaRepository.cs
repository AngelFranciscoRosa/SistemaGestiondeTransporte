using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransporteApp.Entities;
using TransporteApp.DAL.Connection;

namespace TransporteApp.DAL.Repositories
{
    public class RutaRepository
    {
        public void Insertar(Ruta r)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertarRuta", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreRuta", r.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Ruta> Listar()
        {
            var lista = new List<Ruta>();
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarRutas", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Ruta
                    {
                        IdRuta = (int)reader["IdRuta"],
                        Nombre = reader["NombreRuta"].ToString()
                    });
                }
            }

            return lista;
        }

        public void Actualizar(Ruta r)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ActualizarRuta", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdRuta", r.IdRuta);
                cmd.Parameters.AddWithValue("@Nombre", r.Nombre);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarRuta", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdRuta", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}