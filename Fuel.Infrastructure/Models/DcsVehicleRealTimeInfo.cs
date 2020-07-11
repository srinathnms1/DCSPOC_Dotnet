using System;
using System.Collections.Generic;
using System.Collections;

namespace Fuel.Infrastructure.Models
{
    public partial class DcsVehicleRealTimeInfo
    {
        public DcsVehicleRealTimeInfo()
        {
            DcsLocation = new HashSet<DcsLocation>();
        }

        public int VehicleRealTimeInfoId { get; set; }
        public int DriverVehicleId { get; set; }
        public DateTime? PacketTime { get; set; }
        public double? VehicleSpeed { get; set; }
        public int? HarshTurning { get; set; }
        public int? HarshBreaking { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public BitArray IgnitionStatus { get; set; }
        public double? LoadVolume { get; set; }

        public virtual DcsDriverVehicle DriverVehicle { get; set; }
        public virtual ICollection<DcsLocation> DcsLocation { get; set; }
    }
}
