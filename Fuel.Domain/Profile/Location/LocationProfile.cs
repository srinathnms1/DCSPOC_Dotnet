namespace Fuel.Domain.Profile.Location
{
    using Domain.ViewModel;
    using AutoMapper;

    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationViewModel, DcsLocation>()
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Driver.DriverMobile, opt => opt.MapFrom(dest => dest.DriverMobile))
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Driver.DriverName, opt => opt.MapFrom(dest => dest.DriverName))
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Vehicle.VehicleName, opt => opt.MapFrom(dest => dest.VehicleName))
                .ForPath(src => src.VehicleRealTimeInfo.DriverVehicle.Vehicle.VehicleLicenseNo, opt => opt.MapFrom(dest => dest.VehicleLicenseNo))
                .ForPath(src => src.VehicleRealTimeInfo.PacketTime, opt => opt.MapFrom(dist => dist.PacketTime)).ReverseMap();
        }
    }
}
