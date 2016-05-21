using MonitoringApp.BLL;
using Ninject.Modules;

namespace MonitoringApp.Infrastructure
{
    public class TrainsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITrainsService>().To<TrainsService>();
        }
    }
}