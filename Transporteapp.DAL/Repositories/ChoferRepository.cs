using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransporteApp.Entities;
using TransporteApp.DAL.Connection;

namespace TransporteApp.DAL.Repositories
{
    public class ChoferRepository
    {
        public void Insertar(Chofer c)
        {
            var db = new DbConnection();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertarChofer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", c.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Cedula", c.Cedula);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Chofer> Listar()
        {
            var lista = new List<Chofer>();
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarChoferes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Chofer
                    {
                        IdChofer = (int)reader["IdChofer"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        Cedula = reader["Cedula"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Actualizar(Chofer c)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ActualizarChofer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdChofer", c.IdChofer);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", c.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Cedula", c.Cedula);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_EliminarChofer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdChofer", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}