using System.Collections.Generic;
using MonitoringApp.DataAccess.Entities;

namespace MonitoringApp.BLL
{
    public interface ITrainsService
    {
        List<T> GetEntities<T>() where T : class;
        List<int> GetObjectIdList();
        TrainDataCollectedEntity GetTrainObjectEntity(int systemSerialNo);
    }
}