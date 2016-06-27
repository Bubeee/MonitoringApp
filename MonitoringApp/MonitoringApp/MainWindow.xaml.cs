using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MonitoringApp.BLL;
using MonitoringApp.Mappers;
using MonitoringApp.SyncExecutor;
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
        private readonly ISyncExecutor _syncExecutor;
        private BackgroundWorker _backgroundWorker;
        public MainWindow(ITrainsService trainService, ITrainDataMapper trainDataMapper, ISyncExecutor syncExecutor)
        {
            _trainService = trainService;
            _trainDataMapper = trainDataMapper;
            _syncExecutor = syncExecutor;
            InitializeComponent();
        }

        private void TrainsDataGrid_OnSelectionChanged(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
        }

        private void TrainsDataGrid_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _backgroundWorker = (BackgroundWorker)FindResource("BackgroundWorker");
            _backgroundWorker.RunWorkerAsync();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BackgroundWorker_OnDoWork(object sender, DoWorkEventArgs e)
        {
            _syncExecutor.ExecuteSyncronization();
            var objectCollection = new ObjectDataViewModelCollectionWrapper();
            foreach (var systemSerialNo in _trainService.GetObjectIdList())
            {
                var objct = _trainDataMapper.Map(_trainService.GetTrainObjectEntity(systemSerialNo));
                objectCollection.ObjectCollectionViewModels.Add(objct);
            }

            e.Result = objectCollection;
        }

        private void BackgroundWorker_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TrainsDataGrid.DataContext = e.Result;
            UpdateButton.IsEnabled = true;
        }

        private void BackgroundWorker_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateButton.IsEnabled = false;
            if (_backgroundWorker.IsBusy == false)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void TrainsDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedObject = TrainsDataGrid.SelectedItem as ObjectDataViewModel;

            if (selectedObject?.SystemSerialNumber != null)
            {
                var objectWindow = new ObjectDetailsWindow(_trainService, _trainDataMapper,
                    selectedObject.SystemSerialNumber);
                objectWindow.Owner = this;
                objectWindow.Show();
            }
        }
    }
}
