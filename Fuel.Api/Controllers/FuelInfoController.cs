﻿namespace Fuel.Api.Controllers
{
    using Fuel.Api.Infrastructure.Services;
    using Microsoft.AspNetCore.Mvc;
    using Fuel.Api.Models;
    using Microsoft.Extensions.Logging;
    using Fuel.Api.Infrastructure.Extensions;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class FuelInfoController : ControllerBase
    {
        private readonly ILogger<FuelInfoController> _logger;
        private readonly IFuelService _fuelService;

        public FuelInfoController(IFuelService fuelService, ILogger<FuelInfoController> logger)
        {
            _fuelService = fuelService;
            _logger = logger;
        }

        // GET api/fuelinfo
        [HttpGet, Route("")]
        public async Task<IActionResult> GetAsync([FromQuery] FuelInfoRequest fuelInfoServiceRequest)
        {
            _logger.LogInformation($"Requesting fuel information from {this.GetControllerName()}");
            var fuelInfoRequest = new Fuel.Domain.ViewModel.FuelInfoRequest()
            {
                DriverId = fuelInfoServiceRequest.DriverId,
                FromDate = fuelInfoServiceRequest.FromDate.Date,
                ToDate = fuelInfoServiceRequest.ToDate.Date
            };
            var locations = await _fuelService.GetFuelInfoAsync(fuelInfoRequest).ConfigureAwait(false);
            return Ok(locations);
        }
    }
}