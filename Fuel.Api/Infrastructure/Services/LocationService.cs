namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;
    using System.Collections.Generic;
    using Fuel.Domain.ViewModel;
    using AutoMapper;

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public List<LocationViewModel> GetLocations(LocationRequest locationRequest)
        {
            var locations = _locationRepository.GetLocations(locationRequest);
            var bookingVlocationViewModeliewModel = _mapper.Map<List<LocationViewModel>>(locations);
            return bookingVlocationViewModeliewModel;
        }
    }
}
