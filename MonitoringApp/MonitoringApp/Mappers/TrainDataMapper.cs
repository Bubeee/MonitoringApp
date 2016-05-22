using MonitoringApp.DataAccess.Entities;
using MonitoringApp.ViewModels;

namespace MonitoringApp.Mappers
{
    public class TrainDataMapper : ITrainDataMapper
    {
        public ObjectDataViewModel Map(TrainData data)
        {
            return new ObjectDataViewModel
            {
                PackageNumber = data.PackageNumber,
                SystemSerialNumber = data.SystemSerialNumber,
                ProviderName = data.ProviderName,
                IsSystemWorking = data.IsSystemWorking,
                MeasurementDateTime = data.MeasurementDateTime,
                EnvironmentTemperature = data.EnvironmentTemperature,
                Radiator1Temperature = data.Radiator1Temperature,
                Radiator2Temperature = data.Radiator2Temperature,
                FootstepTemperature = data.FootstepTemperature,
                TurbineTemperature = data.TurbineTemperature,
                OilTemperature = data.OilTemperature,
                TransformatorTemperature = data.TransformatorTemperature,
                CabinTemperature = data.CabinTemperature,
                VoltageAKB = data.VoltageAKB,
                Heater1FuelConsumption = data.Heater1FuelConsumption,
                Heater2FuelConsumption = data.Heater2FuelConsumption,
                AirHeaterFuelConsumption = data.AirHeaterFuelConsumption,
                Heater1Flags = data.Heater1Flags,
                Heater2Flags = data.Heater2Flags,
                AirHeaterFlags = data.AirHeaterFlags,
                SystemFlags = data.SystemFlags
            };
        }
    }
}