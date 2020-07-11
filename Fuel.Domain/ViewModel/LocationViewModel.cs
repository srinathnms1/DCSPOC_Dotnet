namespace Fuel.Domain.ViewModel
{
    using System;

    public class LocationViewModel
    {
        public string DriverName { get; set; }
        public string DriverMobile { get; set; }
        public string VehicleLicenseNo { get; set; }
        public string VehicleName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime PacketTime { get; set; }
    }
}
