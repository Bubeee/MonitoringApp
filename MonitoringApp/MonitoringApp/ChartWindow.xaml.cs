using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using MonitoringApp.ViewModels;

namespace MonitoringApp
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        private readonly ObjectDataViewModelCollectionWrapper _dataViewModelCollectionWrapper;
        public ChartWindow(ObjectDataViewModelCollectionWrapper collection)
        {
            _dataViewModelCollectionWrapper = collection;
            InitializeComponent();
        }

        private void LineSeries_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Создание коллекции ключ-значение для потстроения по ней линейного графика
            var linesData = new Dictionary<DateTime, float>();
            for (var i = 0; i + 100 < _dataViewModelCollectionWrapper.ObjectCollectionViewModels.Count; i+=100)
            {
                // Заполнение коллекции значениями дата получения пакета - значение расхода топлива
                var measurementDateTime = _dataViewModelCollectionWrapper.ObjectCollectionViewModels[i].MeasurementDateTime;
                linesData.Add(measurementDateTime,
                    _dataViewModelCollectionWrapper.ObjectCollectionViewModels[i].Heater1FuelConsumption);
            }
            // Передача коллекции в источник данных для линейного графика
            ((LineSeries) Chart.Series[0]).ItemsSource = linesData;
        }

        //private void LoadLineChartData()
        //{
        //    ((LineSeries)LineSeries.Series[0]).ItemsSource =
        //        new KeyValuePair<DateTime, int>[]{
        //newKeyValuePair<DateTime,int>(DateTime.Now, 100),
        //newKeyValuePair<DateTime,int>(DateTime.Now.AddMonths(1), 130),
        //newKeyValuePair<DateTime,int>(DateTime.Now.AddMonths(2), 150),
        //newKeyValuePair<DateTime,int>(DateTime.Now.AddMonths(3), 125),
        //new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(4),155) };
        //}
    }
}
