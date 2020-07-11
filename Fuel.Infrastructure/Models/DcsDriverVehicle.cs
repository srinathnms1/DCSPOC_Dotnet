using System;
using System.Collections.Generic;

namespace Fuel.Infrastructure.Models
{
    public partial class DcsDriverVehicle
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

        public virtual DcsDriverMaster Driver { get; set; }
        public virtual DcsVehicleMaster Vehicle { get; set; }
        public virtual ICollection<DcsDriverService> DcsDriverService { get; set; }
        public virtual ICollection<DcsFuelInfo> DcsFuelInfo { get; set; }
        public virtual ICollection<DcsVehicleRealTimeInfo> DcsVehicleRealTimeInfo { get; set; }
    }
}
