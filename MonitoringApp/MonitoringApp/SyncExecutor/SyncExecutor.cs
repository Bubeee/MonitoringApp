using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace MonitoringApp.SyncExecutor
{
    public class SyncExecutor : ISyncExecutor
    {
        public void ExecuteSyncronization()
        {
            // Создание подключений к клиентской и к серверной Базам Данных
            var clientConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MonitoringAppDb"].ConnectionString);
            var serverConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainsMonitorDb"].ConnectionString);

            // Создание объекта-синхронизатора баз данных
            var syncOrchestrator = new SyncOrchestrator
            {
                LocalProvider = new SqlSyncProvider("TrainsSyncScope", clientConn),
                RemoteProvider = new SqlSyncProvider("TrainsSyncScope", serverConn),
                Direction = SyncDirectionOrder.Download
            };

            //// Подписка на обработку ошибок на клиенте в случае их возникновения
            //((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed +=
            //    new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);

            // Старт процесса синхронизации
            SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();
        }
    }
}
