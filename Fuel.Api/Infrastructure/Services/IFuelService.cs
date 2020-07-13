namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;
    using Fuel.Domain.ViewModel;
    using System.Threading.Tasks;

    public interface IFuelService
    {
        Task<FuelInfoViewModel> GetFuelInfoAsync(FuelInfoRequest fuelInfoRequest);
    }
}
