using System;
using MonitoringApp.DataAccess.Entities;
using MonitoringApp.ViewModels;

namespace MonitoringApp.Mappers
{
    public class TrainDataMapper : ITrainDataMapper
    {
        public ObjectDataViewModel Map(TrainDataCollectedEntity data)
        {
            var result = new ObjectDataViewModel
            {
                PackageNumber = data.PackageNumber ?? 0,
                SystemSerialNumber = data.SystemSerialNumber ?? 0,
                ProviderName = data.ProviderName,
                IsSystemWorking = data.IsSystemWorking ?? false,
                MeasurementDateTime = data.MeasurementDateTime ?? default(DateTime),
                EnvironmentTemperature = data.EnvironmentTemperature ?? 0,
                Radiator1Temperature = data.Radiator1Temperature ?? 0,
                Radiator2Temperature = data.Radiator2Temperature ?? 0,
                FootstepTemperature = data.FootstepTemperature ?? 0,
                TurbineTemperature = data.TurbineTemperature ?? 0,
                OilTemperature = data.OilTemperature ?? 0,
                TransformatorTemperature = data.TransformatorTemperature ?? 0,
                CabinTemperature = data.CabinTemperature ?? 0,
                VoltageAKB = data.VoltageAKB ?? 0,
                Heater1FuelConsumption = data.Heater1FuelConsumption ?? 0,
                Heater2FuelConsumption = data.Heater2FuelConsumption ?? 0,
                AirHeaterFuelConsumption = data.AirHeaterFuelConsumption ?? 0,
                Heater1Flags = data.Heater1Flags ?? 0,
                Heater2Flags = data.Heater2Flags ?? 0,
                AirHeaterFlags = data.AirHeaterFlags ?? 0,
                SystemFlags = data.SystemFlags ?? 0,
                Latitude = data.Latitude ?? 0,
                Longtitude = data.Longtitude ?? 0
            };

            result.Heater1On = result.Heater1Flags << 15 == 1;
            result.Heater1Denials = result.Heater1Flags << 14 == 1 ? HeaterStates.Break : result.Heater1Flags << 13 == 1 ? HeaterStates.ShortCircuit : HeaterStates.NoDenials;
            result.Heater1WaterHeatSystemOn = result.Heater1Flags << 12 == 1;
            result.Heater1CirculationPumpOn = result.Heater1Flags << 11 == 1;
            result.Heater1CirculationPumpVoltageOn = result.Heater1Flags << 10 == 1;
            result.Heater1ErrorNumber = (byte) (result.Heater1Flags << 8);

            result.Heater2On = result.Heater2Flags << 15 == 1;
            result.Heater2Denials = result.Heater2Flags << 14 == 1 ? HeaterStates.Break : result.Heater2Flags << 13 == 1 ? HeaterStates.ShortCircuit : HeaterStates.NoDenials;
            result.Heater2WaterHeatSystemOn = result.Heater2Flags << 12 == 1;
            result.Heater2CirculationPumpOn = result.Heater2Flags << 11 == 1;
            result.Heater2CirculationPumpVoltageOn = result.Heater2Flags << 10 == 1;
            result.Heater2ErrorNumber = (byte) (result.Heater2Flags << 8);

            result.AirHeatSystemOn = result.AirHeaterFlags << 15 == 1;
            result.AirHeaterOn = result.AirHeaterFlags << 14 == 1;
            result.AirHeaterDenials = result.AirHeaterFlags << 12 == 1 ? HeaterStates.Break : HeaterStates.NoDenials;
            result.AirHeaterErrorNumber = (byte)(result.AirHeaterFlags << 8);

            result.V24PowerOn = result.SystemFlags << 7 == 1;
            result.V110PowerOn = result.SystemFlags << 6 == 1;
            result.V220PowerOn = result.SystemFlags << 5 == 1;
            result.AkbChargeOn = result.SystemFlags << 4 == 1;
            result.DieselOn = result.SystemFlags << 3 == 1;
            result.TrainIsMoving = result.SystemFlags << 2 == 1;

            return result;
        }
    }
}