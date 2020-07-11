using System;
using System.Collections.Generic;

namespace Fuel.Infrastructure.Models
{
    public partial class DcsDriverMaster
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

        public virtual ICollection<DcsDriverVehicle> DcsDriverVehicle { get; set; }
    }
}
