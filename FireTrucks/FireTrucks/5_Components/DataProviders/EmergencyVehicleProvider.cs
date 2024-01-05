using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Repositories;

namespace FireTrucks._5_Components.DataProviders;

public class EmergencyVehicleProvider : IVehicleProvider
{
    private readonly IRepository<EmergencyVehicle> _emergencyVehicleRepository;

    public EmergencyVehicleProvider(IRepository<EmergencyVehicle> emergencyVehicleRepository)
    {
        _emergencyVehicleRepository = emergencyVehicleRepository;
    }
    public void AdditionalVehicleInfoProvider()
    {
        throw new NotImplementedException();
    }

}
