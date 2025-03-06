using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace UIAutomation.Src.DB
{
    public class DBFactory
    {

        private string connectionString = ConfigurationManager.AppSettings["DBConnectionString"];

        public DBFactory()
        {
        }

        public DataTable Querry( string query )
        {
            var dataTable = new DataTable();
            using(var connection = new SqlConnection( this.connectionString ))
            {
                connection.Open();
                var command = new SqlCommand( query, connection );
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load( reader );
                }
            }
            return dataTable;
        }
    }
}
