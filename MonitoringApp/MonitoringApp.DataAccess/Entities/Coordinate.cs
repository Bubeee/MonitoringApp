namespace MonitoringApp.DataAccess.Entities
{
    public partial class Coordinate : IEntity
    {
        public int Id { get; set; }

        public double? Latitude { get; set; }

        public double? Longtitude { get; set; }

        public int? RecordId { get; set; }

        public virtual SystemData SystemData { get; set; }
    }
}
