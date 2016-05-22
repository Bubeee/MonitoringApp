using System.Windows;
using System.Windows.Controls;
using MonitoringApp.BLL;
using MonitoringApp.DataAccess.Entities;
using MonitoringApp.Mappers;
using MonitoringApp.ViewModels;

namespace MonitoringApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ITrainsService _trainService;
        private readonly ITrainDataMapper _trainDataMapper;
        public MainWindow(ITrainsService trainService, ITrainDataMapper trainDataMapper)
        {
            _trainService = trainService;
            _trainDataMapper = trainDataMapper;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var objectCollection = new ObjectDataViewModelCollectionWrapper();
            foreach (var systemSerialNo in _trainService.GetEntities<TrainData>())
            {
                var objct = _trainDataMapper.Map(systemSerialNo);
                objectCollection.ObjectCollectionViewModels.Add(objct);
                TrainsDataGrid.Items.Refresh();
            }

            TrainsDataGrid.DataContext = objectCollection;
        }

        private void TrainsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
        }

        private void TrainsDataGrid_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
