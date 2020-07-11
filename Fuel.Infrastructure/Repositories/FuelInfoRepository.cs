namespace Fuel.Infrastructure.Repositories
{
    using Fuel.Domain;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Fuel.Domain.ViewModel;

    public class FuelInfoRepository : GenericRepository<DcsFuelInfo>, IFuelInfoRepository
    {
        public FuelInfoRepository(PostgresContext postgresContext)
        : base(postgresContext)
        {
        }

        public List<DcsFuelInfo> GetFuelInfo(FuelInfoRequest fuelInfoRequest)
        {
            var fuelInfo = GetAll()
                .Where(c => c.DriverVehicle.Driver.DriverId == fuelInfoRequest.DriverId
                && (c.PacketTime.Date >= fuelInfoRequest.FromDate.Date
                && c.PacketTime.Date <= fuelInfoRequest.ToDate.Date))
                .Include(i => i.DriverVehicle).ToList();

            return fuelInfo;
        }
    }
}
