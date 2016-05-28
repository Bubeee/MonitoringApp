using System.Threading;
using System.Windows;
using System.Windows.Media;
using MonitoringApp.Infrastructure;
using Ninject;

namespace MonitoringApp
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        private readonly IAuthenticationModule _authenticationModule;
        public AuthenticationWindow(IAuthenticationModule authenticationModule)
        {
            _authenticationModule = authenticationModule;
            InitializeComponent();
        }

        private void SubmitPassword_OnClick(object sender, RoutedEventArgs e)
        {
            // Stub, the real nothification is gonna be working here
            if (_authenticationModule.Authenticate() == false)
            {
                ValidationLabel.Visibility = Visibility.Visible;
                ValidationLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                ValidationLabel.Content = "Ошибка валидации ключа";
            }
            else
            {
                ValidationLabel.Visibility = Visibility.Visible;
                ValidationLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                ValidationLabel.Content = "Валидация успешна";
            }

            Thread.Sleep(2000);
            IKernel kernel = new StandardKernel(new TrainsNinjectModule());
            kernel.Get<MainWindow>().Show();
            Close();
        }
    }
}
