namespace MonitoringApp.DataAccess.Entities
{
    public partial class Flag
    {
        public int Id { get; set; }

        public int? Heater1Flags { get; set; }

        public int? Heater2Flags { get; set; }

        public int? AirHeaterFlags { get; set; }

        public byte? SystemFlags { get; set; }

        public int? RecordId { get; set; }

        public virtual SystemData SystemData { get; set; }
    }
}
