using System.Windows;
using MonitoringApp.BLL;
using MonitoringApp.DataAccess.Entities;

namespace MonitoringApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ITrainsService _trainService;
        public MainWindow(ITrainsService trainService)
        {
            _trainService = trainService;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = _trainService.GetObjectList().Count.ToString();
        }
    }
}
