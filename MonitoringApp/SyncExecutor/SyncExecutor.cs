﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncExecutor
{
    public class SyncExecutor
    {
        static void Main(string[] args)
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

            // Подписка на обработку ошибок на клиенте в случае их возникновения
            ((SqlSyncProvider) syncOrchestrator.LocalProvider).ApplyChangeFailed +=
                new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);

            // Старт процесса синхронизации
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
