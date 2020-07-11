namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain.ViewModel;
    using System.Collections.Generic;

    public interface ILocationService
    {
        List<LocationViewModel> GetLocations(LocationRequest locationRequest);
    }
}
