namespace MonitoringApp.DataAccess.Entities
{
    public partial class FuelConsumption
    {
        public int Id { get; set; }

        public float? Heater1FuelConsumption { get; set; }

        public float? Heater2FuelConsumption { get; set; }

        public float? AirHeaterFuelConsumption { get; set; }

        public int? RecordId { get; set; }

        public virtual SystemData SystemData { get; set; }
    }
}
