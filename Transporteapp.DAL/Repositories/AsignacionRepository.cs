using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransporteApp.Entities;
using TransporteApp.DAL.Connection;

namespace TransporteApp.DAL.Repositories
{
    public class AsignacionRepository
    {
        // 🔹 CHOFERES DISPONIBLES
        public List<Chofer> GetChoferesDisponibles()
        {
            var lista = new List<Chofer>();
            var db = new DbConnection();

        using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarChoferesDisponibles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Chofer
                    {
                        IdChofer = (int)reader["IdChofer"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }

            return lista;
        }

        // 🔹 AUTOBUSES DISPONIBLES
        public List<Autobus> GetAutobusesDisponibles()
        {
            var lista = new List<Autobus>();
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarAutobusesDisponibles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Autobus
                    {
                        IdAutobus = (int)reader["IdAutobus"],
                        Placa = reader["Placa"].ToString()
                    });
                }
            }

            return lista;
        }

        // 🔹 RUTAS DISPONIBLES
        public List<Ruta> GetRutasDisponibles()
        {
            var lista = new List<Ruta>();
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarRutasDisponibles", conn);
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

        // 🔹 INSERTAR ASIGNACIÓN
        public void Insertar(Asignacion a)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertarAsignacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdChofer", a.IdChofer);
                cmd.Parameters.AddWithValue("@IdAutobus", a.IdAutobus);
                cmd.Parameters.AddWithValue("@IdRuta", a.IdRuta);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarAsignaciones()
        {
            DataTable dt = new DataTable();
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarAsignaciones", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
    }


}
