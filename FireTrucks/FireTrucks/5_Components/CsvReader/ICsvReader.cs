using FireTrucks._1_DataAccess.Entities;

namespace FireTrucks._5_Components.CsvReader;

public interface ICsvReader
{
    List<EmergencyVehicle> ProcessEmergencyVehicles(string filePath);

    List<FirefightingVehicle> ProcessFirefightingVehicles(string filePath);

    public void AddEmergencyVehiclesFromCSVFileToDbContext();
    public void AddFirefightingVehicleFromCSVFileToDbContext();
}