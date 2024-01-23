using FireTrucks._1_DataAccess;
using FireTrucks._1_DataAccess.Entities;
using FireTrucks._5_Components.CsvReader.Extensions;

namespace FireTrucks._5_Components.CsvReader;

public class CsvReader : ICsvReader
{

    public readonly FireTrucksDbContext _fireTrucksDbContext;

    public CsvReader(FireTrucksDbContext fireTrucksDbContext)
    {
        _fireTrucksDbContext = fireTrucksDbContext;
    }

    public List<EmergencyVehicle> ProcessEmergencyVehicles(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<EmergencyVehicle>();
        }
        var emergancyVehicles = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToEmergencyVehicle();
        return emergancyVehicles.ToList();
    }

    public List<FirefightingVehicle> ProcessFirefightingVehicles(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<FirefightingVehicle>();
        }

        var firefightingVehicles = File.ReadAllLines(filePath)
             .Skip(1)
             .Where(x => x.Length > 1)
             .ToFirefightingVehicleExtensions();
        return firefightingVehicles.ToList();
    }

    public void AddEmergencyVehiclesFromCSVFileToDbContext()
    {
        var emergencyVehicles = ProcessEmergencyVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\EmergencyVehicle.csv");
        foreach (var emergencyVehicle in emergencyVehicles)
        {
            _fireTrucksDbContext.EmergencyCars.Add(new EmergencyVehicle
            {
                Manufacturer = emergencyVehicle.Manufacturer,
                YearOfProduction = emergencyVehicle.YearOfProduction,
                VehicleCategory = emergencyVehicle.VehicleCategory,
                Weight = emergencyVehicle.Weight,
                NumbersOfSeats = emergencyVehicle.NumbersOfSeats,
                DateTimeChanges = DateTime.Now,
                OtherEquipment = new List<string> { "Hydraulic Gear" }
            });

            _fireTrucksDbContext.SaveChanges();
        }
    }
    public void AddFirefightingVehicleFromCSVFileToDbContext()
    {
        var firefighterVehicles = ProcessFirefightingVehicles(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files\FirefightingVehicle.csv");
        foreach (var firefighterVehicle in firefighterVehicles)
        {
            _fireTrucksDbContext.FirefightingVehicles.Add(new FirefightingVehicle
            {
                Manufacturer = firefighterVehicle.Manufacturer,
                YearOfProduction = firefighterVehicle.YearOfProduction,
                VehicleCategory = firefighterVehicle.VehicleCategory,
                Weight = firefighterVehicle.Weight,
                NumbersOfSeats = firefighterVehicle.NumbersOfSeats,
                SizeOfWaterReservoir = firefighterVehicle.SizeOfWaterReservoir,
                SizeOfFoamConcentrateTank = firefighterVehicle.SizeOfFoamConcentrateTank,
                CarPumpEfficiency = firefighterVehicle.CarPumpEfficiency,
                WaterCannonEfficiency = firefighterVehicle.WaterCannonEfficiency,
                NumbersOfFireHoses = firefighterVehicle.NumbersOfFireHoses,
                DateTimeChanges = DateTime.Now,
                OtherEquipment = new List<string> { }
            });
            _fireTrucksDbContext.SaveChanges();
        }
    }
}