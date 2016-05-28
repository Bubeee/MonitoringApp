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
            // Соединиться с сервером
            var serverConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainsMonitorDb"].ConnectionString);

            // Создать рамки синхронизации 
            var scopeDesc = new DbSyncScopeDescription("TrainsSyncScope");

            // Получить описание таблиц базы данных сервера
            var tableDesc1 = SqlSyncDescriptionBuilder.GetDescriptionForTable("SystemData", serverConn);
            var tableDesc2 = SqlSyncDescriptionBuilder.GetDescriptionForTable("Coordinates", serverConn);
            var tableDesc3 = SqlSyncDescriptionBuilder.GetDescriptionForTable("Temperatures", serverConn);
            var tableDesc4 = SqlSyncDescriptionBuilder.GetDescriptionForTable("Flags", serverConn);
            var tableDesc5 = SqlSyncDescriptionBuilder.GetDescriptionForTable("FuelConsumptions", serverConn);
            var tableDesc6 = SqlSyncDescriptionBuilder.GetDescriptionForTable("TrainData", serverConn);

            // Добавить описание таблиц в рамки синхронизации
            scopeDesc.Tables.Add(tableDesc1);
            scopeDesc.Tables.Add(tableDesc2);
            scopeDesc.Tables.Add(tableDesc3);
            scopeDesc.Tables.Add(tableDesc4);
            scopeDesc.Tables.Add(tableDesc5);
            scopeDesc.Tables.Add(tableDesc6);

            // Создать провайдера синхронизации
            var serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

            // Начать процесс настройки синхронизации
            serverProvision.Apply();
        }
    }
}
