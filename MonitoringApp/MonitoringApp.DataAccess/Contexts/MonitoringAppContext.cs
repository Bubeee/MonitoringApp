using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;
using MonitoringApp.DataAccess.Entities;

namespace MonitoringApp.DataAccess.Contexts
{
    public partial class MonitoringAppContext : DbContext
    {
        public MonitoringAppContext()
            : base("name=MonitoringAppDb")
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

        public List<int> GetObjectIdList()
        {
            var query = "SELECT [SystemSerialNumber] " +
                        "FROM [monitoringAppDb].[dbo].[SystemData] " +
                        "GROUP BY [SystemSerialNumber]";

            var result = Database.Connection.Query<int>(query).ToList();
            return result;
        }

        public TrainDataCollectedEntity GetTrainObjectEntity(int systemSerialNo)
        {
            var query = "SELECT TOP 1 * FROM [dbo].[SystemData] AS [SD] " +
                        "INNER JOIN [Temperatures] AS [T] ON [SD].[Id] = [T].[RecordId] " +
                        "INNER JOIN [Flags] AS [F] ON [SD].[Id] = [F].[RecordId] " +
                        "INNER JOIN [FuelConsumptions] AS [FC] ON [SD].[Id] = [FC].[RecordId] " +
                        "INNER JOIN [Coordinates] AS [C] ON [SD].[Id] = [C].[RecordId] " +
                        "WHERE [SystemSerialNumber] = @systemSerialNo " +
                        "ORDER BY [MeasurementDateTime] DESC";

            return Database.Connection.Query<TrainDataCollectedEntity>(query, new { systemSerialNo }).First();
        }
    }
}