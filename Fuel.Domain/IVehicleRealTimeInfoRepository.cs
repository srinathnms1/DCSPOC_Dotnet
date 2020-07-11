namespace Fuel.Domain
{
    using DcsService.Core;
    using System.Collections.Generic;

    public interface IVehicleRealTimeInfoRepository : IGenericRepository<DcsVehicleRealTimeInfo>
    {
        List<DcsVehicleRealTimeInfo> GetAllInfo();
    }
}
