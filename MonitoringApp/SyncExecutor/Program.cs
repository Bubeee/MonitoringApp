using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncExecutor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MonitoringAppDb"].ConnectionString);
            
            var serverConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainsMonitorDb"].ConnectionString);

            // create the sync orhcestrator
            var syncOrchestrator = new SyncOrchestrator
            {
                LocalProvider = new SqlSyncProvider("TrainsSyncScope", clientConn),
                RemoteProvider = new SqlSyncProvider("TrainsSyncScope", serverConn),
                Direction = SyncDirectionOrder.Download
            };

            // subscribe for errors that occur when applying changes to the client
            ((SqlSyncProvider) syncOrchestrator.LocalProvider).ApplyChangeFailed +=
                new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);

            // execute the synchronization process
            SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

            // print statistics
            Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
            Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
            Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
            Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
            Console.WriteLine(string.Empty);
            Console.ReadKey();
        }

        static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            // display conflict type
            Console.WriteLine(e.Conflict.Type);

            // display error message 
            Console.WriteLine(e.Error);
        }
    }
}
