using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MonitoringApp.BLL;
using MonitoringApp.DataAccess.Entities;
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

        private void TrainsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
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
        }

        private void BackgroundWorker_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
        }
    }
}
