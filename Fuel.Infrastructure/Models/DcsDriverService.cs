﻿using System;
using System.Collections.Generic;

namespace Fuel.Infrastructure.Models
{
    public partial class DcsDriverService
    {
        public int DriverServiceId { get; set; }
        public int DriverVehicleId { get; set; }
        public DateTime? VehicleStartTime { get; set; }
        public DateTime? VehicleEndTime { get; set; }
        public DateTime? RestingStartTime { get; set; }
        public DateTime? RestingEndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public double? RestTimeHours { get; set; }
        public double? DrivingTimeHours { get; set; }
        public double? WorkTimeHours { get; set; }
        public double? DistanceTravelled { get; set; }

        public virtual DcsDriverVehicle DriverVehicle { get; set; }
    }
}
