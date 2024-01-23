using FireTrucks._1_DataAccess.Entities;

namespace FireTrucks._5_Components.DataProviders
{
    public interface IEmergencyVehicleProvider
    {
        List<EmergencyVehicle> OrderByManufacturerDescending();

        List<EmergencyVehicle> OrderByYearOfProductionDescending();

        List<EmergencyVehicle> OrderByNumbersOfSeatsThanByWeight();

        List<EmergencyVehicle> OrderByWeightVehicleCategoryThanByCategory();

        List<EmergencyVehicle> FindVehicleWhereWeightIsLikeUserChose();
    }
}