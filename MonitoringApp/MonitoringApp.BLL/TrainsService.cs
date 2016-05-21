using System.Collections.Generic;
using System.Linq;
using MonitoringApp.DataAccess.Contexts;

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

        public List<int> GetObjectList()
        {
            using (var dbContext = new MonitoringAppContext())
            {
                var listOfSystemSerialNos =
                    dbContext.SystemDatas.Select(data => data.SystemSerialNumber).GroupBy(i => i.Value).Select(ints => ints.Key);

                return listOfSystemSerialNos.ToList();
            }
        }
    }
}
