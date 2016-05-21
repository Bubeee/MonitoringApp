using System.Collections.Generic;

namespace MonitoringApp.BLL
{
    public interface ITrainsService
    {
        List<T> GetEntities<T>() where T : class;
        List<int> GetObjectList();
    }
}