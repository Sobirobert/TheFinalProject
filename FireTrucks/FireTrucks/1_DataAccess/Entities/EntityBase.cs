namespace FireTrucks._1_DataAccess.Entities;

public abstract class EntityBase : IEntity
{
    public int Id { get; set; }
    public int YearOfProduction { get; set; }
    public string Manufacturer { get; set; }
    public Equipment Equipment { get; set; }
    public List<string> OtherEquipment { get; set; }

    public override string ToString() => $"Id: {Id}";

    public void ShowAllOtherEquipment(List<string> listString)
    {
        foreach (var item in listString)
        {
            Console.WriteLine($"Equipment: {item}");
        }
    }
}