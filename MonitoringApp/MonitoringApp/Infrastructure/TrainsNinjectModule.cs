using System.Configuration;
using MonitoringApp.BLL;
using MonitoringApp.DataAccess.Factories;
using MonitoringApp.DataAccess.Repositories;
using MonitoringApp.Mappers;
using MonitoringApp.SyncExecutor;
using Ninject.Modules;

namespace MonitoringApp.Infrastructure
{
    public class TrainsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITrainsService>().To<TrainsService>();
            Bind<IRepository>().To<MonitoringAppRepository>();

            Bind<IDbConnectionFactory>()
                .To<SqlConnectionFactory>()
                .WithConstructorArgument("connectionString",
                    ConfigurationManager.ConnectionStrings["MonitoringAppDb"].ConnectionString);

            Bind<ITrainDataMapper>().To<TrainDataMapper>();
            Bind<IAuthenticationModule>().To<KeyAuthenticationModule>();
            Bind<ISyncExecutor>().To<SyncExecutor.SyncExecutor>();
        }
    }
}