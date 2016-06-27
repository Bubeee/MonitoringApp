
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MonitoringApp.DataAccess.Factories
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        IDbConnection IDbConnectionFactory.CreateConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
