using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Entities.Extensions;

namespace FireTrucks._5_Components.CsvReader.Extensions;

public static class EmergencyVehicleExtensions
{
    public static IEnumerable<EmergencyVehicle> ToEmergencyVehicle(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');

            yield return new EmergencyVehicle
            {
                Manufacturer = columns[0],
                YearOfProduction = int.Parse(columns[1]),
                VehicleCategory = Enum.Parse<VehicleCategory>(columns[2]),
                Weight = Enum.Parse<Weight>(columns[3]),
                NumbersOfSeats = int.Parse(columns[4]),
                Equipment = List<Equipment>(columns[5]),
                OtherEquipment = columns[11].Split(',').ToList(),
            };
        }
    }
}