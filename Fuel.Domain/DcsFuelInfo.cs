namespace Fuel.Domain
{
    using System;

    public class DcsFuelInfo
    {
        public int DriverVehicleId { get; set; }
        public int FuelInfoId { get; set; }
        public double CurrentVolume { get; set; }
        public double RefuelVolume { get; set; }
        public DateTime PacketTime { get; set; }
        public DcsDriverVehicle DriverVehicle { get; set; }
    }
}
