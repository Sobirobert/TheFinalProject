
using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Repositories;

namespace FireTrucks._5_Components.DataProviders;

public class FirefightingVehicleProvider : IVehicleProvider
{
    private readonly IRepository<FirefightingVehicle> _firefightingVehicleRepository;

    public FirefightingVehicleProvider(IRepository<FirefightingVehicle> firefightingVehicleRepository)
    {
        _firefightingVehicleRepository = firefightingVehicleRepository;
    }

    //public List<FoodProduct> OrderByNameDescending()
    //{
    //    var entitys = _foodProductRepository.GetAll();
    //    return entitys.OrderByDescending(x => x.Name).ToList();
    //}

    //public List<FoodProduct> OrderByCountDescending()
    //{
    //    var entitys = _foodProductRepository.GetAll();
    //    return entitys.OrderByDescending(x => x.Count).ToList();
    //}

    //public List<FoodProduct> OrderByLocation()
    //{
    //    var entitys = _foodProductRepository.GetAll();
    //    return entitys.OrderByDescending(x => x.Location).ToList();
    //}

    //public List<FoodProduct> SelectByLocationFridge()
    //{
    //    var entitys = _foodProductRepository.GetAll();
    //    return entitys.Where(x => x.Location == "Fridge").ToList();
    //}

    public void AdditionalVehicleInfoProvider()
    {
        throw new NotImplementedException();
    }
}