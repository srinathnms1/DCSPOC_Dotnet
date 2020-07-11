namespace Fuel.Infrastructure.Repositories
{
    using Fuel.Domain;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class VehicleRealTimeInfoRepository : GenericRepository<DcsVehicleRealTimeInfo>, IVehicleRealTimeInfoRepository
    {
        public VehicleRealTimeInfoRepository(PostgresContext postgresContext)
        : base(postgresContext)
        {
        }

        public List<DcsVehicleRealTimeInfo> GetAllInfo()
        {
            return GetAll().Include(i => i.DriverVehicle).ToList();
        }
    }
}
