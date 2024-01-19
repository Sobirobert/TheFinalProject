using FireTrucks._1_DataAccess.Entities;

namespace FireTrucks._5_Components.DataProviders;

public interface IFirefightingVehicleProvider
{
    List<FirefightingVehicle> OrderByManufacturerDescending();

    List<FirefightingVehicle> OrderByYearOfProductionDescending();

    List<FirefightingVehicle> OrderByNumbersOfSeats();

    List<FirefightingVehicle> OrderBySizeOfWaterReservoir();

    List<FirefightingVehicle> FindVehicleWhereWeightIsLikeUserChose();
}