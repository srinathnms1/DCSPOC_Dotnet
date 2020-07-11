namespace Fuel.Domain
{
    using System;
    using System.Collections.Generic;

    public class DcsLocation
    {
        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int VehicleRealTimeInfoId { get; set; }

        public DcsVehicleRealTimeInfo VehicleRealTimeInfo { get; set; }
    }
}
