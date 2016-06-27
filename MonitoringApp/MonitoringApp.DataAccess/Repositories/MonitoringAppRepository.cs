using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MonitoringApp.DataAccess.Entities;
using MonitoringApp.DataAccess.Factories;
using Ninject;

namespace MonitoringApp.DataAccess.Repositories
{
    public class MonitoringAppRepository : IRepository
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public List<int> GetObjectIdList()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                var query = "SELECT [SystemSerialNumber] " +
                       "FROM [monitoringAppDb].[dbo].[TrainData] " +
                       "GROUP BY [SystemSerialNumber]";

                var result = dbConnection.Query<int>(query).ToList();
                return result;
            }
        }

        public TrainDataCollectedEntity GetTrainObjectEntity(int systemSerialNo)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                var query = "SELECT TOP 1 * FROM [dbo].[TrainData] " +
                                       "WHERE [SystemSerialNumber] = @systemSerialNo " +
                                       "ORDER BY [MeasurementDateTime] DESC";

                return dbConnection.Query<TrainDataCollectedEntity>(query, new { systemSerialNo }).First();
            }
        }

        public IEnumerable<TrainDataCollectedEntity> GetTrainObjectDataCollectedEntities(int systemSerialNo, DateTime from, DateTime to)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                var query = "SELECT * FROM [dbo].[TrainData] " +
                            "WHERE[SystemSerialNumber] = @systemSerialNo " +
                            "AND [MeasurementDateTime] > @from " +
                            "AND [MeasurementDateTime] < @to " +
                            "ORDER BY[MeasurementDateTime] DESC";

                return dbConnection.Query<TrainDataCollectedEntity>(query, new { systemSerialNo, from, to });
            }
        }
    }
}