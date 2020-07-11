namespace Fuel.Domain
{
    using System;
    using System.Collections.Generic;

    public class DcsDriverVehicle
    {
        public DcsDriverVehicle()
        {
            DcsDriverService = new HashSet<DcsDriverService>();
            DcsFuelInfo = new HashSet<DcsFuelInfo>();
            DcsVehicleRealTimeInfo = new HashSet<DcsVehicleRealTimeInfo>();
        }

        public int DriverVehicleId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public DcsDriverMaster Driver { get; set; }
        public DcsVehicleMaster Vehicle { get; set; }
        public ICollection<DcsDriverService> DcsDriverService { get; set; }
        public ICollection<DcsFuelInfo> DcsFuelInfo { get; set; }
        public ICollection<DcsVehicleRealTimeInfo> DcsVehicleRealTimeInfo { get; set; }
    }
}
