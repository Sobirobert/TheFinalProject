using FireTrucks._1_DataAccess.Entities;
using FireTrucks._5_Components.CsvReader.Extensions;

namespace FireTrucks._5_Components.CsvReader;

public class CsvReader : ICsvReader
{
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
}