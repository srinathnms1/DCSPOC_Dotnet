namespace Fuel.Domain
{
    using DcsService.Core;
    using Fuel.Domain.ViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFuelInfoRepository : IGenericRepository<DcsFuelInfo>
    {
        Task<List<DcsFuelInfo>> GetFuelInfo(FuelInfoRequest fuelInfoRequest);
    }
}
