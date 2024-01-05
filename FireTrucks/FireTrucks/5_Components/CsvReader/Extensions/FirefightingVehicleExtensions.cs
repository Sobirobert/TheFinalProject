using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Entities.Extensions;

namespace FireTrucks._5_Components.CsvReader.Extensions;

public static class FirefightingVehicleExtensions
{
    public static IEnumerable<FirefightingVehicle> ToFirefightingVehicleExtensions(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');

            yield return new FirefightingVehicle
            {
                Manufacturer = columns[0],
                YearOfProduction = int.Parse(columns[1]),
                VehicleCategory = Enum.Parse<VehicleCategory>(columns[2]),
                Weight = Enum.Parse<Weight>(columns[3]),
                NumbersOfSeats = int.Parse(columns[4]),
                SizeOfWaterReservoir = double.Parse(columns[6]),
                SizeOfFoamConcentrateTank = double.Parse(columns[7]),
                CarPumpEfficiency = double.Parse(columns[8]),
                WaterCannonEfficiency = double.Parse(columns[9]),
                Equipment = List<Equipment>(columns[5]),
                OtherEquipment = columns[11].Split(',').ToList(),
                NumbersOfFireHoses = int.Parse(columns[12]),
            };
        }
    }
}