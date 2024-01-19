namespace FireTrucks._1_DataAccess.Entities;

public class Trailer : EntityBase
{
    public double Tonnage { get; set; }
    public DateTime DateTimeChanges { get; set; }

    public override string ToString() => $"Manufacturer: {Manufacturer}\n, Year Of Production: {YearOfProduction}\n" +
                                         $"Equipment: {Equipment}\n, Tonnage: {Tonnage}\n, Date time of changes: {DateTimeChanges}\n" +
                                         $"Other Equipment: {ShowAllOtherEquipment}";
}