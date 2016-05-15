using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitoringApp.DataAccess.Entities
{
    [Table("SystemData")]
    public partial class SystemData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SystemData()
        {
            Coordinates = new HashSet<Coordinate>();
            Flags = new HashSet<Flag>();
            FuelConsumptions = new HashSet<FuelConsumption>();
            Temperatures = new HashSet<Temperature>();
        }

        public int Id { get; set; }

        public int? PackageNumber { get; set; }

        public int? SystemSerialNumber { get; set; }

        [StringLength(15)]
        public string ProviderName { get; set; }

        public bool? IsSystemWorking { get; set; }

        public DateTime? MeasurementDateTime { get; set; }

        public float? VoltageAKB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coordinate> Coordinates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flag> Flags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuelConsumption> FuelConsumptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Temperature> Temperatures { get; set; }
    }
}
