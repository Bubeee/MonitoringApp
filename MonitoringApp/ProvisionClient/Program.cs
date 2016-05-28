using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Synchronization.Data.SqlServer;

namespace ProvisionClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создание соединения с базой данных клиента
            var clientConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MonitoringAppDb"].ConnectionString);

            // создание соединения с базой данных сервера
            var serverConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainsMonitorDb"].ConnectionString);

            // получение информации о рамках синхронизации баз данных
            var scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("TrainsSyncScope", serverConn);

            // создание провайдера синхронизации на стороне клиента
            var clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);

            // применение настроек провайдера синхронизации к клиенту
            clientProvision.Apply();
        }
    }
}