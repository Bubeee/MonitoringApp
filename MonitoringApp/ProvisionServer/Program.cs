using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace DataSyncronizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // connect to server database
            var serverConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainsMonitorDb"].ConnectionString);

            // define a new scope named TrainsSyncScope
            var scopeDesc = new DbSyncScopeDescription("TrainsSyncScope");

            // get the description of the Products table from SyncDB dtabase
            var tableDesc1 = SqlSyncDescriptionBuilder.GetDescriptionForTable("SystemData", serverConn);
            var tableDesc2 = SqlSyncDescriptionBuilder.GetDescriptionForTable("Coordinates", serverConn);
            var tableDesc3 = SqlSyncDescriptionBuilder.GetDescriptionForTable("Temperatures", serverConn);
            var tableDesc4 = SqlSyncDescriptionBuilder.GetDescriptionForTable("Flags", serverConn);
            var tableDesc5 = SqlSyncDescriptionBuilder.GetDescriptionForTable("FuelConsumptions", serverConn);
            var tableDesc6 = SqlSyncDescriptionBuilder.GetDescriptionForTable("TrainData", serverConn);

            // add the table description to the sync scope definition
            scopeDesc.Tables.Add(tableDesc1);
            scopeDesc.Tables.Add(tableDesc2);
            scopeDesc.Tables.Add(tableDesc3);
            scopeDesc.Tables.Add(tableDesc4);
            scopeDesc.Tables.Add(tableDesc5);
            scopeDesc.Tables.Add(tableDesc6);

            // create a server scope provisioning object based on the ProductScope
            var serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

            // skipping the creation of table since table already exists on server
            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

            // start the provisioning process
            serverProvision.Apply();
        }
    }
}
