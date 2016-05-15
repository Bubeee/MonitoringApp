using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Synchronization.Data.SqlServer;

namespace ProvisionClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a connection to the SyncExpressDB database
            var clientConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MonitoringAppDb"].ConnectionString);
            
            // create a connection to the SyncDB server database
            var serverConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainsMonitorDb"].ConnectionString);

            // get the description of ProductsScope from the SyncDB server database
            var scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("TrainsSyncScope", serverConn);

            // create server provisioning object based on the ProductsScope
            var clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);

            // starts the provisioning process
            clientProvision.Apply();
        }
    }
}