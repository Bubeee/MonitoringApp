using System;
using System.Collections.Generic;
using MonitoringApp.DataAccess.Entities;
using MonitoringApp.DataAccess.Factories;

namespace MonitoringApp.DataAccess.Repositories
{
    public interface IRepository
    {
        IDbConnectionFactory DbConnectionFactory { get; set; }

        List<int> GetObjectIdList();

        TrainDataCollectedEntity GetTrainObjectEntity(int systemSerialNo);

        IEnumerable<TrainDataCollectedEntity> GetTrainObjectDataCollectedEntities(int systemSerialNo,
            DateTime from, DateTime to);
    }
}