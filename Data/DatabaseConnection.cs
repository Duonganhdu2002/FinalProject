using System.Data.SqlClient;

namespace FinalProject.Data
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString = @"Data Source=Wydanhdu\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";

        public static SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
}
