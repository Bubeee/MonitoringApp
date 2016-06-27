using System;
using System.ComponentModel.DataAnnotations;
using MonitoringApp.Mappers;

namespace MonitoringApp.ViewModels
{
    public class ObjectDataViewModel
    {
        public int PackageNumber { get; set; }

        public int SystemSerialNumber { get; set; }

        [StringLength(15)]
        public string ProviderName { get; set; }

        public bool IsSystemWorking { get; set; }

        public DateTime MeasurementDateTime { get; set; }

        public float EnvironmentTemperature { get; set; }

        public float Radiator1Temperature { get; set; }

        public float Radiator2Temperature { get; set; }

        public float FootstepTemperature { get; set; }

        public float TurbineTemperature { get; set; }

        public float OilTemperature { get; set; }

        public float TransformatorTemperature { get; set; }

        public float CabinTemperature { get; set; }

        public float VoltageAKB { get; set; }

        public float Heater1FuelConsumption { get; set; }

        public float Heater2FuelConsumption { get; set; }

        public float AirHeaterFuelConsumption { get; set; }

        public int Heater1Flags { get; set; }

        public bool Heater1On { get; set; }
        public HeaterStates Heater1Denials { get; set; }
        public bool Heater1WaterHeatSystemOn { get; set; }
        public bool Heater1CirculationPumpOn { get; set; }
        public bool Heater1CirculationPumpVoltageOn { get; set; }
        public byte Heater1ErrorNumber { get; set; }

        public int Heater2Flags { get; set; }


        public bool Heater2On { get; set; }
        public HeaterStates Heater2Denials { get; set; }
        public bool Heater2WaterHeatSystemOn { get; set; }
        public bool Heater2CirculationPumpOn { get; set; }
        public bool Heater2CirculationPumpVoltageOn { get; set; }
        public byte Heater2ErrorNumber { get; set; }

        public int AirHeaterFlags { get; set; }

        public bool AirHeaterOn { get; set; }
        public HeaterStates AirHeaterDenials { get; set; }
        public bool AirHeatSystemOn { get; set; }
        public byte AirHeaterErrorNumber { get; set; }

        public byte SystemFlags { get; set; }
        public bool V24PowerOn { get; set; }
        public bool V110PowerOn { get; set; }
        public bool V220PowerOn { get; set; }
        public bool AkbChargeOn { get; set; }
        public bool DieselOn { get; set; }
        public bool TrainIsMoving { get; set; }
        

        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}
