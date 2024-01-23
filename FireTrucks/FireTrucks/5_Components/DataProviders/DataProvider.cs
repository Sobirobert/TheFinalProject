using FireTrucks._1_DataAccess;
using FireTrucks._1_DataAccess.Entities;
using FireTrucks._5_Components.CsvReader;

namespace FireTrucks._5_Components.DataProviders;

public class DataProvider : IDataProvider
{
    private readonly ICsvReader _csvReader;

    public DataProvider(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void AdditionalVehicleInfoProvider()
    {
        var emergencyVehicles = _csvReader.ProcessEmergencyVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\EmergencyVehicle.csv");
        var firefightingVehicles = _csvReader.ProcessFirefightingVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\FirefightingVehicle.csv");

        GroupManufacturersByDisplacement(emergencyVehicles);

        GroupManufacturersByName(firefightingVehicles);

        JoinManufacturersAndCars(emergencyVehicles, firefightingVehicles);
    }

    private void GroupManufacturersByDisplacement(List<EmergencyVehicle> emergencyVehicles)
    {
        var groups = emergencyVehicles.GroupBy(x => x.Manufacturer)
          .Select(g => new
          {
              Manufacturer = g.Key,
              YearOfProduction = g.Max(x => x.YearOfProduction),
          })
          .OrderByDescending(x => x.YearOfProduction);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Manufacturer}\n" +
                $"\tcombined max: {group.YearOfProduction}\n");
        }
    }

    private static void JoinManufacturersAndCars(List<EmergencyVehicle> emergencyVehicles, List<FirefightingVehicle> firefightingVehicles)
    {
        var carsInCountry = emergencyVehicles.Join(
            firefightingVehicles,
            c => c.Manufacturer,
            m => m.Manufacturer,
            (emergencyVehicles, firefightingVehicles) => new
            {
                firefightingVehicles.NumbersOfFireHoses,
                emergencyVehicles.Manufacturer,
                emergencyVehicles.YearOfProduction,
                firefightingVehicles.CarPumpEfficiency,
                firefightingVehicles.NumbersOfSeats
            })
            .OrderByDescending(x => x.Manufacturer)
            .ThenBy(x => x.YearOfProduction);

        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Manufacturer: {car.Manufacturer}");
            Console.WriteLine($"\t CarPumpEfficiency: {car.CarPumpEfficiency}");
            Console.WriteLine($"\t NumbersOfSeats: {car.NumbersOfSeats}");
            Console.WriteLine($"\t YearOfProduction: {car.YearOfProduction}");
            Console.WriteLine($"\t NumbersOfFireHoses: {car.NumbersOfFireHoses}");
        }
    }

    private void GroupManufacturersByName(List<FirefightingVehicle> firefightingVehicle)
    {
        var groups = firefightingVehicle.GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Manufacturer = g.Key,
                Max = g.Max(c => c.NumbersOfSeats),
                Min = g.Min(c => c.YearOfProduction),
                Average = Math.Round(g.Average(c => c.NumbersOfFireHoses), 2)
            })
            .OrderBy(x => x.Manufacturer);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Manufacturer}\n" +
                $"\tcombined max: {group.Max}\n" +
                $"\tcombined min: {group.Min}\n" +
                $"\tcombined avr: {group.Average}\n");
        }
    }
}