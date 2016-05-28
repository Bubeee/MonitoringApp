using System.Collections.Generic;
using System.Linq;
using MonitoringApp.DataAccess.Contexts;
using MonitoringApp.DataAccess.Entities;

namespace MonitoringApp.BLL
{
    public class TrainsService : ITrainsService
    {
        List<T> ITrainsService.GetEntities<T>()
        {
            using (var dbContext = new MonitoringAppContext())
            {
                var listOfEntities = dbContext.Set<T>().ToList();
                return listOfEntities;
            }
        }

        public List<int> GetObjectIdList()
        {
            using (var dbContext = new MonitoringAppContext())
            {
                return dbContext.GetObjectIdList();
            }
        }

        public TrainDataCollectedEntity GetTrainObjectEntity(int systemSerialNo)
        {
            using (var dbContext = new MonitoringAppContext())
            {
                return dbContext.GetTrainObjectEntity(systemSerialNo);
            }
        }
    }
}
