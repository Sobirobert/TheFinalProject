using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Repositories;

namespace FireTrucks._2_ApplicationServices;

public class EventHandlerServices : IEventHandlerServices
{
    private readonly IRepository<EmergencyVehicle> _emergencyVehicleRepository;
    private readonly IRepository<FirefightingVehicle> _firefightingVehicleRepository;
    private readonly IRepository<Trailer> _trailerRepository;

    public EventHandlerServices(IRepository<EmergencyVehicle> emergencyVehicleRepository, IRepository<FirefightingVehicle> firefightingVehicleRepository, IRepository<Trailer> trailerRepository)
    {
        _emergencyVehicleRepository = emergencyVehicleRepository;
        _firefightingVehicleRepository = firefightingVehicleRepository;
        _trailerRepository = trailerRepository;
    }


    public void SubscribeToEvents()
    {
        _emergencyVehicleRepository.ItemAdded += EmergencyVehicleRepositoryOnItemAdded;
        _firefightingVehicleRepository.ItemAdded += FirefightingVehicleRepositoryOnItemAdded;
        _trailerRepository.ItemAdded += TrailerRepositoryOnItemAdded;
        _emergencyVehicleRepository.ItemRemoved += EmergencyVehicleRepositoryOnItemRemove;
        _firefightingVehicleRepository.ItemRemoved += FirefightingVehicleRepositoryOnItemRemove;
        _trailerRepository.ItemRemoved += TrailerRepositoryOnItemRemove;
    }

    public void EmergencyVehicleRepositoryOnItemAdded(object? sender, EmergencyVehicle e)
    {
        Console.WriteLine($"Emergency Vehicle: {e.Id} {e.Manufacturer} added");
    }

    public void EmergencyVehicleRepositoryOnItemRemove(object? sender, EmergencyVehicle e)
    {
        Console.WriteLine($"Emergency Vehicle: {e.Id} {e.Manufacturer} deleted");
    }

    public void FirefightingVehicleRepositoryOnItemAdded(object? sender, FirefightingVehicle e)
    {
        Console.WriteLine($"Firefighting Vehicle: {e.Id} {e.Manufacturer} added");
    }

    public void FirefightingVehicleRepositoryOnItemRemove(object? sender, FirefightingVehicle e)
    {
        Console.WriteLine($"Firefighting Vehicle:{e.Id} {e.Manufacturer} deleted");
    }

    public void TrailerRepositoryOnItemAdded(object? sender, Trailer e)
    {
        Console.WriteLine($"Trailer: {e.Id} {e.Manufacturer} added");
    }

    public void TrailerRepositoryOnItemRemove(object? sender, Trailer e)
    {
        Console.WriteLine($"Trailer: {e.Id} {e.Manufacturer} deleted");
    }
}
