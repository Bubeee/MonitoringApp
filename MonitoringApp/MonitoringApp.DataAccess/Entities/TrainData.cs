using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringApp.DataAccess.Entities
{
    [Table("TrainData")]
    public partial class TrainData : IEntity
    {
        public int Id { get; set; }

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
    }
}
