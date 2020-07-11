using System;
using System.Collections.Generic;

namespace Fuel.Infrastructure.Models
{
    public partial class DcsFuelInfo
    {
        public int DriverVehicleId { get; set; }
        public int FuelInfoId { get; set; }
        public double? CurrentVolume { get; set; }
        public double? RefuelVolume { get; set; }
        public DateTime? PacketTime { get; set; }

        public virtual DcsDriverVehicle DriverVehicle { get; set; }
    }
}
