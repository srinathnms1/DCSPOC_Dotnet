namespace Fuel.Domain
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DcsVehicleRealTimeInfo
    {
        public DcsVehicleRealTimeInfo()
        {
            DcsLocation = new HashSet<DcsLocation>();
        }

        public int VehicleRealTimeInfoId { get; set; }
        public int DriverVehicleId { get; set; }
        public DateTime PacketTime { get; set; }
        public double? VehicleSpeed { get; set; }
        public int? HarshTurning { get; set; }
        public int? HarshBreaking { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public BitArray IgnitionStatus { get; set; }
        public double? LoadVolume { get; set; }

        public DcsDriverVehicle DriverVehicle { get; set; }
        public ICollection<DcsLocation> DcsLocation { get; set; }
    }
}
