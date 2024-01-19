using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Entities.Extensions;
using System.Globalization;

namespace FireTrucks._5_Components.CsvReader.Extensions;

public static class FirefightingVehicleExtensions
{
    public static IEnumerable<FirefightingVehicle> ToFirefightingVehicleExtensions(this IEnumerable<string> source)
    {
        CultureInfo culture = new CultureInfo("pl-PL");
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
                SizeOfWaterReservoir = double.Parse((columns[5]).ToString().Replace('.', ',')),
                SizeOfFoamConcentrateTank = double.Parse((columns[6]).ToString().Replace('.', ',')),
                CarPumpEfficiency = double.Parse((columns[7]).ToString().Replace('.', ',')),
                WaterCannonEfficiency = double.Parse((columns[8]).ToString().Replace('.', ',')),
                NumbersOfFireHoses = int.Parse(columns[9]),
                OtherEquipment = new List<string> { columns[10] }
            };
        }
    }
}