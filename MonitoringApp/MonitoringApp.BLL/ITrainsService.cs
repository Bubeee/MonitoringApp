using System;
using System.Collections.Generic;
using MonitoringApp.DataAccess.Entities;

namespace MonitoringApp.BLL
{
    public interface ITrainsService
    {
        List<int> GetObjectIdList();
        TrainDataCollectedEntity GetTrainObjectEntity(int systemSerialNo);
        List<TrainDataCollectedEntity> GetTrainObjectPackages(int systemSerialNo, DateTime from, DateTime to);
    }
}