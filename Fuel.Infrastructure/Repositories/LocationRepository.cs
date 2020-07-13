namespace Fuel.Infrastructure.Repositories
{
    using Fuel.Domain;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Fuel.Domain.ViewModel;
    using System.Threading.Tasks;

    public class LocationRepository : GenericRepository<DcsLocation>, ILocationRepository
    {
        public LocationRepository(PostgresContext postgresContext)
        : base(postgresContext)
        {
        }

        public Task<List<DcsLocation>> GetLocations(LocationRequest locationRequest)
        {
            var locations = GetAll().Include(i => i.VehicleRealTimeInfo)
                .Where(c => c.VehicleRealTimeInfo.DriverVehicle.Driver.DriverId == locationRequest.DriverId
                && (c.VehicleRealTimeInfo.PacketTime.Date >= locationRequest.FromDate.Date
                && c.VehicleRealTimeInfo.PacketTime.Date <= locationRequest.ToDate.Date))
                .Include(i => i.VehicleRealTimeInfo.DriverVehicle.Driver)
                .Include(i => i.VehicleRealTimeInfo.DriverVehicle.Vehicle).ToList();
            return Task.Run(() => locations);
        }
    }
}
