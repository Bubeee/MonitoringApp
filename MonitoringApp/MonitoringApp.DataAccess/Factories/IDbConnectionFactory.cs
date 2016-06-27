using System.Data;

namespace MonitoringApp.DataAccess.Factories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
