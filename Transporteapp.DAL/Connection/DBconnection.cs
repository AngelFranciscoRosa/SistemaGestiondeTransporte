using System.Data.SqlClient;

namespace TransporteApp.DAL.Connection
{
    public class DbConnection
    {
        private string connectionString = "Server=.;Database=TransporteDB;Trusted_Connection=True;";


    public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }


}

