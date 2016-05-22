using System.Data.Entity.Infrastructure;
using MonitoringApp.BLL;
using MonitoringApp.Mappers;
using Ninject.Modules;

namespace MonitoringApp.Infrastructure
{
    public class TrainsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITrainsService>().To<TrainsService>();
            Bind<IDbConnectionFactory>().To<SqlCeConnectionFactory>();
            Bind<ITrainDataMapper>().To<TrainDataMapper>();
        }
    }
}