namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;
    using Fuel.Domain.ViewModel;

    public interface IFuelService
    {
        FuelInfoViewModel GetFuelInfo(FuelInfoRequest fuelInfoRequest);
    }
}
