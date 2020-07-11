namespace Fuel.Domain
{
    using System;
    using System.Collections.Generic;

    public class DcsDriverMaster
    {
        public DcsDriverMaster()
        {
            DcsDriverVehicle = new HashSet<DcsDriverVehicle>();
        }

        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverMobile { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<DcsDriverVehicle> DcsDriverVehicle { get; set; }
    }
}
