using MonitoringApp.DataAccess.Entities;
using MonitoringApp.ViewModels;

namespace MonitoringApp.Mappers
{
    public interface ITrainDataMapper
    {
        ObjectDataViewModel Map(TrainDataCollectedEntity data);
    }
}