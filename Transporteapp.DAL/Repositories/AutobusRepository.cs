using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransporteApp.Entities;
using TransporteApp.DAL.Connection;

namespace TransporteApp.DAL.Repositories
{
    public class AutobusRepository
    {
        // INSERTAR
        public void Insertar(Autobus a)
        {
            var db = new DbConnection();

        using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertarAutobus", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Marca", a.Marca);
                cmd.Parameters.AddWithValue("@Modelo", a.Modelo);
                cmd.Parameters.AddWithValue("@Placa", a.Placa);
                cmd.Parameters.AddWithValue("@Color", a.Color);
                cmd.Parameters.AddWithValue("@Anio", a.Anio);

                cmd.ExecuteNonQuery();
            }
        }

        // LISTAR
        public List<Autobus> Listar()
        {
            var lista = new List<Autobus>();
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarAutobuses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Autobus
                    {
                        IdAutobus = (int)reader["IdAutobus"],
                        Marca = reader["Marca"].ToString(),
                        Modelo = reader["Modelo"].ToString(),
                        Placa = reader["Placa"].ToString(),
                        Color = reader["Color"].ToString(),
                        Anio = (int)reader["Anio"]
                    });
                }
            }

            return lista;
        }

        // ACTUALIZAR
        public void Actualizar(Autobus a)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ActualizarAutobus", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAutobus", a.IdAutobus);
                cmd.Parameters.AddWithValue("@Marca", a.Marca);
                cmd.Parameters.AddWithValue("@Modelo", a.Modelo);
                cmd.Parameters.AddWithValue("@Placa", a.Placa);
                cmd.Parameters.AddWithValue("@Color", a.Color);
                cmd.Parameters.AddWithValue("@Anio", a.Anio);

                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR
        public void Eliminar(int id)
        {
            var db = new DbConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_EliminarAutobus", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAutobus", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
