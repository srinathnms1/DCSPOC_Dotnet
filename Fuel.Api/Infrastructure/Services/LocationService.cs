namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;
    using System.Collections.Generic;
    using Fuel.Domain.ViewModel;
    using AutoMapper;
    using System.Threading.Tasks;

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<List<LocationViewModel>> GetLocationsAsync(LocationRequest locationRequest)
        {
            var locations = await _locationRepository.GetLocations(locationRequest).ConfigureAwait(false);
            var locationViewModel = _mapper.Map<List<LocationViewModel>>(locations);
            return locationViewModel;
        }
    }
}
