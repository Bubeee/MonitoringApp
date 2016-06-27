using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MonitoringApp.BLL;
using MonitoringApp.Mappers;
using MonitoringApp.ViewModels;

namespace MonitoringApp
{
    /// <summary>
    /// Interaction logic for ObjectDetailsWindow.xaml
    /// </summary>
    public partial class ObjectDetailsWindow : Window
    {
        private readonly ITrainsService _trainService;
        private readonly ITrainDataMapper _trainDataMapper;
        private readonly int _systemSerialNo;

        public ObjectDetailsWindow(ITrainsService trainService, ITrainDataMapper trainDataMapper, int systemSerialNo)
        {
            _trainService = trainService;
            _trainDataMapper = trainDataMapper;
            _systemSerialNo = systemSerialNo;
            InitializeComponent();
        }

        private void TrainsDataGrid_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void ObjectDetails_OnLoaded(object sender, RoutedEventArgs e)
        {
            var objectCollection = new ObjectDataViewModelCollectionWrapper();

            foreach (var item in _trainService.GetTrainObjectPackages(_systemSerialNo, DateTime.Now.AddDays(-6666),
                        DateTime.Now))
            {
                objectCollection.ObjectCollectionViewModels.Add(_trainDataMapper.Map(item));
            }

            ObjectDataGrid.DataContext = objectCollection;
        }

        private void MenuItemClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemChart_OnClick(object sender, RoutedEventArgs e)
        {
            var chartWindow = new ChartWindow((ObjectDataViewModelCollectionWrapper)ObjectDataGrid.DataContext);
            chartWindow.Show();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.csv)|*.csv";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ObjectDataGrid.SelectAllCells();
                ObjectDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, ObjectDataGrid);
                ObjectDataGrid.UnselectAllCells();
                string result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);

                File.WriteAllText(saveFileDialog.FileName, result, Encoding.UTF8);
            }
        }
    }
}