namespace Fuel.Domain.Profile.Location
{
    using Domain.ViewModel;
    using AutoMapper;

    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationViewModel, DcsLocation>()
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Driver.DriverMobile, opt => opt.MapFrom(dist => dist.DriverMobile))
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Driver.DriverName, opt => opt.MapFrom(dist => dist.DriverName))
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Vehicle.VehicleName, opt => opt.MapFrom(dist => dist.VehicleName))
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Vehicle.VehicleLicenseNo, opt => opt.MapFrom(dist => dist.VehicleLicenseNo))
                .ForPath(src => src.VehicleRealTimeInfo.PacketTime, opt => opt.MapFrom(dist => dist.PacketTime)).ReverseMap();
        }
    }
}
