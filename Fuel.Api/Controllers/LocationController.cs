namespace Fuel.Api.Controllers
{
    using Fuel.Api.Infrastructure.Services;
    using Fuel.Api.Models;
    using Microsoft.AspNetCore.Mvc;
    using Fuel.Api.Infrastructure.Extensions;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<FuelInfoController> _logger;
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService, ILogger<FuelInfoController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        // GET api/fuelinfo
        [HttpGet, Route("")]
        public IActionResult Get([FromQuery] LocationRequest locationServiceRequest)
        {
            _logger.LogInformation($"Requesting fuel information from {this.GetControllerName()}");
            var locationRequest = new Fuel.Domain.ViewModel.LocationRequest() { 
                DriverId = locationServiceRequest.DriverId,
                FromDate = locationServiceRequest.FromDate, 
                ToDate = locationServiceRequest.ToDate
            };
            var locations = _locationService.GetLocations(locationRequest);
            return Ok(locations);
        }
    }
}