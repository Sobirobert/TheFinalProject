
using FireTrucks._1_DataAccess.Entities.Extensions;
using System.Drawing;

namespace FireTrucks._1_DataAccess.Entities;

public class FirefightingVehicle : EntityBase
{
    public DateTime DateTimeChanges { get; set; }
    public VehicleCategory VehicleCategory { get; set; }
    public int NumbersOfSeats { get; set; }
    public Weight Weight { get; set; }
    public double SizeOfWaterReservoir { get; set; }
    public double SizeOfFoamConcentrateTank { get; set; }
    public double CarPumpEfficiency { get; set; }
    public double WaterCannonEfficiency { get; set; }
    public int NumbersOfFireHoses { get; set; }

    public override string ToString() => $"Id: {Id}\n, Manufacturer: {Manufacturer}\n, Year Of Production: {YearOfProduction}\n, " +
                                         $"Type of Car: {VehicleCategory}\n, Weight: {Weight}\n, Numbers of seats: {NumbersOfSeats}\n," +
                                         $"Size of water reservoir: {SizeOfWaterReservoir}\n, Size of foam concentrate tank: {SizeOfFoamConcentrateTank}\n, Car pump efficiency: {CarPumpEfficiency}\n, " +
                                         $"Water cannon efficiency: {WaterCannonEfficiency}\n, Equipment: {ShowAllEquipment}\n, " +
                                         $"Other Equipment: {ShowAllOtherEquipment}\n, Numbers of fire hoses: {NumbersOfFireHoses}\n, Date time of changes: {DateTimeChanges}\n,";
}
