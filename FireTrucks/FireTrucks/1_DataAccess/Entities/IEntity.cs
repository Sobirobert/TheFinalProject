namespace FireTrucks._1_DataAccess.Entities;

public interface IEntity
{
    int Id { get; set; }
    int YearOfProduction { get; set; }
    string Manufacturer { get; set; }
    Equipment Equipment { get; set; }
    List<string> OtherEquipment { get; set; }
}