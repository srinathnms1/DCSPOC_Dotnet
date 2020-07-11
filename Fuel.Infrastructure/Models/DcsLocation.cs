using System;
using System.Collections.Generic;

namespace Fuel.Infrastructure.Models
{
    public partial class DcsLocation
    {
        public int LocationId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int VehicleRealTimeInfoId { get; set; }

        public virtual DcsVehicleRealTimeInfo VehicleRealTimeInfo { get; set; }
    }
}
