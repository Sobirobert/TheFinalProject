using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Entities.Extensions;
using FireTrucks._1_DataAccess.Repositories;
using FireTrucks._2_ApplicationServices;

namespace FireTrucks._5_Components.DataProviders;

public class FirefightingVehicleProvider : UserCommunicationBase, IFirefightingVehicleProvider
{
    private readonly IRepository<FirefightingVehicle> _firefightingVehicleRepository;

    public FirefightingVehicleProvider(IRepository<FirefightingVehicle> firefightingVehicleRepository)
    {
        _firefightingVehicleRepository = firefightingVehicleRepository;
    }

    public List<FirefightingVehicle> OrderByManufacturerDescending()
    {
        var entitys = _firefightingVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.Manufacturer).ToList();
    }

    public List<FirefightingVehicle> OrderByYearOfProductionDescending()
    {
        var entitys = _firefightingVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.YearOfProduction).TakeWhile(x => x.YearOfProduction > 2017).ToList();
    }

    public List<FirefightingVehicle> OrderByNumbersOfSeats()
    {
        var entitys = _firefightingVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.NumbersOfSeats).ToList();
    }

    public List<FirefightingVehicle> OrderBySizeOfWaterReservoir()
    {
        var entitys = _firefightingVehicleRepository.GetAll();
        return entitys.OrderByDescending(x => x.SizeOfWaterReservoir).ToList();
    }

    public List<FirefightingVehicle> FindVehicleWhereWeightIsLikeUserChose()
    {
        var userInPut = GetInputFromUserAndReturnIntNoGreaterThan3("Chose vehicle weight: 1 - Light, 2 - Mediocre, 3 - Heavy");
        var entitys = _firefightingVehicleRepository.GetAll();
        return entitys.Where(x => x.Weight == (Weight)userInPut).ToList();
    }
}