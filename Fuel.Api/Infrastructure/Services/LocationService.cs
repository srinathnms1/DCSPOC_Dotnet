namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;
    using System.Collections.Generic;
    using Fuel.Domain.ViewModel;

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public List<LocationViewModel> GetLocations(LocationRequest locationRequest)
        {
            var locations = _locationRepository.GetLocations(locationRequest);
            var locationViewModel = new List<LocationViewModel>();
            locations.ForEach(c => locationViewModel.Add(new LocationViewModel()
            {
                DriverMobile = c.VehicleRealTimeInfo.DriverVehicle.Driver.DriverMobile,
                DriverName = c.VehicleRealTimeInfo.DriverVehicle.Driver.DriverName,
                VehicleName = c.VehicleRealTimeInfo.DriverVehicle.Vehicle.VehicleName,
                VehicleLicenseNo = c.VehicleRealTimeInfo.DriverVehicle.Vehicle.VehicleLicenseNo,
                Latitude = c.Latitude,
                Longitude = c.Longitude,
                PacketTime = c.VehicleRealTimeInfo.PacketTime
            }));
            return locationViewModel;
        }
    }
}
