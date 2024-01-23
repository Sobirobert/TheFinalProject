using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Entities.Extensions;
using FireTrucks._1_DataAccess.Repositories;
using FireTrucks._2_ApplicationServices;

namespace FireTrucks._5_Components.DataProviders;

public class EmergencyVehicleProvider : UserCommunicationBase, IEmergencyVehicleProvider
{
    private readonly IRepository<EmergencyVehicle> _emergencyVehicleRepository;

    public EmergencyVehicleProvider(IRepository<EmergencyVehicle> emergencyVehicleRepository)
    {
        _emergencyVehicleRepository = emergencyVehicleRepository;
    }

    public List<EmergencyVehicle> OrderByManufacturerDescending()
    {
        var entitys = _emergencyVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.Manufacturer).ToList();
    }

    public List<EmergencyVehicle> OrderByYearOfProductionDescending()
    {
        var entitys = _emergencyVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.YearOfProduction).Where(x => x.YearOfProduction > 2016).ToList();
    }

    public List<EmergencyVehicle> OrderByNumbersOfSeatsThanByWeight()
    {
        var entitys = _emergencyVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.NumbersOfSeats).ThenBy(x => x.Weight).ToList();
    }

    public List<EmergencyVehicle> OrderByWeightVehicleCategoryThanByCategory()
    {
        var entitys = _emergencyVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.Weight).ThenBy(x => x.VehicleCategory).ToList();
    }

    public List<EmergencyVehicle> FindVehicleWhereWeightIsLikeUserChose()
    {
        var userInPut = GetInputFromUserAndReturnIntNoGreaterThan3("Chose vehicle weight: 1 - Light, 2 - Mediocre, 3 - Heavy");
        var entitys = _emergencyVehicleRepository.GetAll();
        return entitys.Where(x => x.Weight == (Weight)userInPut).ToList();
    }

}