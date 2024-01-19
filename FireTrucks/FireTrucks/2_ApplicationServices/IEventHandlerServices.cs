using FireTrucks._1_DataAccess.Entities;

namespace FireTrucks._2_ApplicationServices;

public interface IEventHandlerServices
{
    void EmergencyVehicleRepositoryOnItemAdded(object? sender, EmergencyVehicle e);

    void FirefightingVehicleRepositoryOnItemAdded(object? sender, FirefightingVehicle e);

    void TrailerRepositoryOnItemAdded(object? sender, Trailer e);

    void EmergencyVehicleRepositoryOnItemRemove(object? sender, EmergencyVehicle e);

    void FirefightingVehicleRepositoryOnItemRemove(object? sender, FirefightingVehicle e);

    void TrailerRepositoryOnItemRemove(object? sender, Trailer e);

    void SubscribeToEvents();
}