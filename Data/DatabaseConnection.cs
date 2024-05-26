using System.Data.SqlClient;

namespace FinalProject.Data
{
    public class DatabaseConnection
    {
        private SqlConnection connection;

        public DatabaseConnection()
        {
            string connectionString = @"Data Source=Wydanhdu\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
