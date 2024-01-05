
namespace FireTrucks._5_Components.DataProviders;

public class DataProvider : IDataProvider
{
    private readonly ICsvReader _csvReader;

    public DataProvider(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void GenerateDataFromCsvFile()
    {
        var cars = _csvReader.ProcessCars(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files.csv");
        var manufacturers = _csvReader.ProcessManufacturesrs(@"D:\repos4\TheFinalProject\FireTrucks\FireTrucks\4_Resources\Files.csv");

        GroupManufacturersByDisplacement(cars);

        GroupManufacturersByName(cars);

        JoinManufacturersAndCars(cars, manufacturers);

        JoinManufacturersAndCarsGroupByManufacturer(cars, manufacturers);
    }

    private void GroupManufacturersByDisplacement(List<Car> cars)
    {
        var groups = cars.GroupBy(x => x.Manufacturer)
          .Select(g => new
          {
              Name = g.Key,
              Displacement = g.Max(x => x.Displacement),
          })
          .OrderByDescending(x => x.Displacement);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}\n" +
                $"\tcombined max: {group.Displacement}\n");
        }
    }

    private void JoinManufacturersAndCarsGroupByManufacturer(List<Car> cars, List<Manufacture> manufacturers)
    {
        var groupsJoined = manufacturers.GroupJoin(
            cars,
            m => new { Manufacturer = m.Name, m.Year },
            c => new { c.Manufacturer, c.Year },
            (m, c) =>
                new
                {
                    Manufacturer = m,
                    Cars = c
                }
            )
            .OrderBy(x => x.Manufacturer.Name);

        foreach (var car in groupsJoined)
        {
            Console.WriteLine($" {car.Manufacturer.Name}");
            Console.WriteLine($"\t Cars: {car.Cars.Count()}");
            Console.WriteLine($"\t Max: {car.Cars.Max(x => x.Combined)}");
            Console.WriteLine($"\t Min: {car.Cars.Min(x => x.Combined)}");
            Console.WriteLine($"\t Avg: {car.Cars.Average(x => x.Combined)}");
            Console.WriteLine();
        }
    }

    private static void JoinManufacturersAndCars(List<Car> cars, List<Manufacture> manufacturers)
    {
        var carsInCountry = cars.Join(
            manufacturers,
            c => c.Manufacturer,
            m => m.Name,
            (car, manufacturer) => new
            {
                manufacturer.Country,
                car.Manufacturer,
                car.Name,
                car.Combined,
                car.Cylinders
            })
            .OrderByDescending(x => x.Name)
            .ThenBy(x => x.Name);

        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Country: {car.Country}");
            Console.WriteLine($"\t Name: {car.Manufacturer} {car.Name}");
            Console.WriteLine($"\t Combined: {car.Combined}");
        }
    }

    private void GroupManufacturersByName(List<Car> cars)
    {
        var groups = cars.GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Min = g.Min(c => c.Combined),
                Average = Math.Round(g.Average(c => c.Combined), 2)
            })
            .OrderBy(x => x.Name);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}\n" +
                $"\tcombined max: {group.Max}\n" +
                $"\tcombined min: {group.Min}\n" +
                $"\tcombined avr: {group.Average}\n");
        }
    }
}