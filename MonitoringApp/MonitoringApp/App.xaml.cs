using System.Windows;
using MonitoringApp.Infrastructure;
using Ninject;

namespace MonitoringApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IKernel kernel = new StandardKernel(new TrainsNinjectModule());
            kernel.Get<AuthenticationWindow>().Show();
        }
    }
}
