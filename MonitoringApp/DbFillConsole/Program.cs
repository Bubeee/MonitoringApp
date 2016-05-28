using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace DbFillConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MonitoringAppDb"].ConnectionString))
            {
                var query = "";
                connection.Query();
            }
        }
    }
}
