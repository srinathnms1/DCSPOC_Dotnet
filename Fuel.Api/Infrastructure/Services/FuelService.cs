namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;
    using Fuel.Domain.ViewModel;
    using System;
    using System.Collections.Generic;

    public class FuelService : IFuelService
    {
        private readonly IFuelInfoRepository _fuelInfoRepository;
        private readonly IVehicleRealTimeInfoRepository _vehicleRealTimeInfoRepository;

        public FuelService(IFuelInfoRepository fuelInfoRepository, IVehicleRealTimeInfoRepository vehicleRealTimeInfoRepository)
        {
            _fuelInfoRepository = fuelInfoRepository;
            _vehicleRealTimeInfoRepository = vehicleRealTimeInfoRepository;
        }

        public FuelInfoViewModel GetFuelInfo(FuelInfoRequest fuelInfoRequest)
        {
            var fuelInfo = _fuelInfoRepository.GetFuelInfo(fuelInfoRequest);
            var fuleInfoModelList = new List<FuelInfoModel>();
            var refuelModelList = new List<FuelInfoModel>();
            var leakageModelList = new List<FuelInfoModel>();
            var theftModelList = new List<FuelInfoModel>();
            double previousVolume = 0;
            foreach (var data in fuelInfo)
            {
                fuleInfoModelList.Add(new FuelInfoModel() { VehicleId = data.DriverVehicle.VehicleId, Volume = data.CurrentVolume, PacketTime = data.PacketTime });
                if (data.RefuelVolume > 0)
                {
                    refuelModelList.Add(new FuelInfoModel() { 
                        VehicleId = data.DriverVehicle.VehicleId, 
                        Volume = Math.Round(data.RefuelVolume, 2),
                        PacketTime = data.PacketTime
                    });
                }
                if (previousVolume > 0 && (previousVolume - data.CurrentVolume) >= 5 && (previousVolume - data.CurrentVolume) <= 40)
                {
                    leakageModelList.Add(new FuelInfoModel() { VehicleId = data.DriverVehicle.VehicleId, Volume = Math.Round(previousVolume - data.CurrentVolume, 2), PacketTime = data.PacketTime });
                }
                if (previousVolume > 0 && data.RefuelVolume == 0 && (previousVolume - data.CurrentVolume) >= 50)
                {
                    theftModelList.Add(new FuelInfoModel() { VehicleId = data.DriverVehicle.VehicleId, Volume = Math.Round(previousVolume - data.CurrentVolume, 2), PacketTime = data.PacketTime });
                }
                previousVolume = data.CurrentVolume;
            }

            var fuelInfoViewModel = new FuelInfoViewModel()
            {
                FuelInfoModel = fuleInfoModelList,
                RefuelModel = refuelModelList,
                LeakageModel = leakageModelList,
                TheftModel = theftModelList
            };

            return fuelInfoViewModel;
        }
    }

    public class FuelInfoViewModel
    {
        public List<FuelInfoModel> FuelInfoModel { get; set; }
        public List<FuelInfoModel> RefuelModel { get; set; }
        public List<FuelInfoModel> LeakageModel { get; set; }
        public List<FuelInfoModel> TheftModel { get; set; }
    }

    public class FuelInfoModel
    {
        public int VehicleId { get; set; }
        public double Volume { get; set; }
        public DateTime PacketTime { get; set; }
    }
}
