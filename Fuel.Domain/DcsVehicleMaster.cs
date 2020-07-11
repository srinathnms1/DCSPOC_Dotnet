namespace Fuel.Domain
{
    using System;
    using System.Collections.Generic;

    public class DcsVehicleMaster
    {
        public DcsVehicleMaster()
        {
            DcsDriverVehicle = new HashSet<DcsDriverVehicle>();
        }

        public int VehicleId { get; set; }
        public string VehicleLicenseNo { get; set; }
        public string VehicleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public double? TankCapacity { get; set; }

        public ICollection<DcsDriverVehicle> DcsDriverVehicle { get; set; }
    }
}
