using System.Data.Entity;
using MonitoringApp.DataAccess.Entities;

namespace MonitoringApp.DataAccess.Contexts
{
    public partial class TrainsMonitorContext : DbContext
    {
        public TrainsMonitorContext()
            : base("name=TrainsMonitorDb")
        {
        }

        public virtual DbSet<Coordinate> Coordinates { get; set; }
        public virtual DbSet<Flag> Flags { get; set; }
        public virtual DbSet<FuelConsumption> FuelConsumptions { get; set; }
        public virtual DbSet<SystemData> SystemDatas { get; set; }
        public virtual DbSet<Temperature> Temperatures { get; set; }
        public virtual DbSet<TrainData> TrainDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemData>()
                .HasMany(e => e.Coordinates)
                .WithOptional(e => e.SystemData)
                .HasForeignKey(e => e.RecordId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SystemData>()
                .HasMany(e => e.Flags)
                .WithOptional(e => e.SystemData)
                .HasForeignKey(e => e.RecordId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SystemData>()
                .HasMany(e => e.FuelConsumptions)
                .WithOptional(e => e.SystemData)
                .HasForeignKey(e => e.RecordId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SystemData>()
                .HasMany(e => e.Temperatures)
                .WithOptional(e => e.SystemData)
                .HasForeignKey(e => e.RecordId)
                .WillCascadeOnDelete();
        }
    }
}
