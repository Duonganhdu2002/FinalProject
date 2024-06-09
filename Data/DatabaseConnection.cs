using System.Data.SqlClient;

namespace FinalProject.Data
{
    public class DatabaseConnection
    {
        private SqlConnection connection;
        private string connectionString; // Define the connection string as a class-level variable

        public DatabaseConnection()
        {
            connectionString = @"Data Source=Wydanhdu\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";
            connection = new SqlConnection(); // Initialize the connection without the connection string
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.ConnectionString = connectionString; // Set the connection string here
                Console.WriteLine($"Connection String: {connection.ConnectionString}"); // Debug: Check if the connection string is set
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
