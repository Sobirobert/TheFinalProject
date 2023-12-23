
using FireTrucks._1_DataAccess.Entities.Extensions;

namespace FireTrucks._1_DataAccess.Entities;

public class EmergencyVehicle : EntityBase
{
    public DateTime DateTimeChanges { get; set; }
    public VehicleCategory VehicleCategory { get; set; }
    public int NumbersOfSeats { get; set; }
    public Weight Weight { get; set; }

    public override string ToString() => $"Id: {Id}\n, Manufacturer: {Manufacturer}\n, Year Of Production: {YearOfProduction}\n, Type of Car: {VehicleCategory}\n" +
                                         $"Weight: {Weight}\n, Numbers of seats: {NumbersOfSeats}\n,  Date time of changes: {DateTimeChanges}\n, Equipment: {ShowAllEquipment}\n, " +
                                         $"Other Equipment: {ShowAllOtherEquipment}\n,";
}
