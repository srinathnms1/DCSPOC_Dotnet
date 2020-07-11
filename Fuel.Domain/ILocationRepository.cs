namespace Fuel.Domain
{
    using DcsService.Core;
    using Fuel.Domain.ViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationRepository : IGenericRepository<DcsLocation>
    {
        List<DcsLocation> GetLocations(LocationRequest locationRequest);
    }
}
