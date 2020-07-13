namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain.ViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationService
    {
        Task<List<LocationViewModel>> GetLocationsAsync(LocationRequest locationRequest);
    }
}
