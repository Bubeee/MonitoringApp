using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using MonitoringApp.Annotations;

namespace MonitoringApp.ViewModels
{
    public class ObjectDataViewModel : INotifyPropertyChanged
    {
        public int? PackageNumber { get; set; }

        public int? SystemSerialNumber { get; set; }

        [StringLength(15)]
        public string ProviderName { get; set; }

        public bool? IsSystemWorking { get; set; }

        public DateTime? MeasurementDateTime { get; set; }

        public float? EnvironmentTemperature { get; set; }

        public float? Radiator1Temperature { get; set; }

        public float? Radiator2Temperature { get; set; }

        public float? FootstepTemperature { get; set; }

        public float? TurbineTemperature { get; set; }

        public float? OilTemperature { get; set; }

        public float? TransformatorTemperature { get; set; }

        public float? CabinTemperature { get; set; }

        public float? VoltageAKB { get; set; }

        public float? Heater1FuelConsumption { get; set; }

        public float? Heater2FuelConsumption { get; set; }

        public float? AirHeaterFuelConsumption { get; set; }

        public int? Heater1Flags { get; set; }

        public int? Heater2Flags { get; set; }

        public int? AirHeaterFlags { get; set; }

        public byte? SystemFlags { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
