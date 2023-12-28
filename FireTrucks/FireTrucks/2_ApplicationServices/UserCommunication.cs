
using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Entities.Extensions;
using FireTrucks._1_DataAccess.Repositories;

namespace FireTrucks._2_ApplicationServices;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly IRepository<EmergencyVehicle> _emergencyVehicleRepository;
    private readonly IRepository<FirefightingVehicle> _firefightingVehicleRepository;
    private readonly IRepository<Trailer> _trailerRepository;
    public UserCommunication(IRepository<Trailer> trailerRepository, IRepository<EmergencyVehicle> emergencyVehicleRepository, IRepository<FirefightingVehicle> firefightingVehicleRepository)
    {
        _emergencyVehicleRepository = emergencyVehicleRepository;
        _firefightingVehicleRepository = firefightingVehicleRepository;
        _trailerRepository = trailerRepository;
    }
    public void Menu()
    {
        while (true)
        {
            var userInPut = GetInputFromUserAndReturnString("Hello User.\n" +
                                                            "Choose option\n" +
                                                            "Press 1 to Add new car or trailer\n" +
                                                            "Press 2 to show all cars and trailers\n" +
                                                            "Press 3 to find car or trailer by ID\n" +
                                                            "Press 4 to clear car or trailer from file by ID\n" +
                                                            "Press 5 to use additional option\n" +
                                                            "To exit insert 'x'\n").ToUpper();

            switch (userInPut)
            {
                case "1":
                    var inPut = GetInputFromUserAndReturnInt("\n Which Entities do you want to add ? \n Press: \n 1 - Emergency Vehicles,\n 2 - Firefighting Vehicle,\n 3 - Trailers.\n");
                    if (inPut == 1)
                    {
                        AddNewEmergencyVehicle(_emergencyVehicleRepository);
                        Console.WriteLine($"Success");
                    }
                    else if (inPut == 2)
                    {
                        AddNewFirefightingVehicle(_firefightingVehicleRepository);
                        Console.WriteLine("Success");
                    }
                    else if (inPut == 3)
                    {
                        AddNewTrailer(_trailerRepository);
                        Console.WriteLine("Success");
                    }
                    break;

                case "2":
                    WriteAllToConsole(_emergencyVehicleRepository);
                    WriteAllToConsole(_firefightingVehicleRepository);
                    WriteAllToConsole(_trailerRepository);
                    break;

                case "3":
                    var userInPut2 = GetInputFromUserAndReturnInt("\nWhich Entities do you want to find by Id ? \n Press 1 - Emergency Vehicles, 2 - Firefighting Vehicles, 3 - Trailers.\n");
                    if (userInPut2 == 1)
                    {
                        FindProductById(_emergencyVehicleRepository);
                        Console.WriteLine($"Success");
                    }
                    else if (userInPut2 == 2)
                    {
                        FindProductById(_firefightingVehicleRepository);
                        Console.WriteLine("Success");
                    }
                    else if (userInPut2 == 3)
                    {
                        FindProductById(_trailerRepository);
                        Console.WriteLine("Success");
                    }
                    break;

                case "4":
                    var userInPut3 = GetInputFromUserAndReturnInt("\nWhich Entities do you want remove by Id ? \n Press 1 - Emergency Vehicles, 2 - Firefighting Vehicles, 3 - Trailers.\n");
                    if (userInPut3 == 1)
                    {
                        RemoveObjectFromEntitie(_emergencyVehicleRepository);
                        Console.WriteLine($"Success");
                    }
                    else if (userInPut3 == 2)
                    {
                        RemoveObjectFromEntitie(_firefightingVehicleRepository);
                        Console.WriteLine("Success");
                    }
                    else if (userInPut3 == 3)
                    {
                        RemoveObjectFromEntitie(_trailerRepository);
                        Console.WriteLine("Success");
                    }
                    break;

                case "5":
                    //_additionalOption.Menu();
                    break;

                case "X":
                    return;

                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
    }
    private void RemoveObjectFromEntitie<T>(IRepository<T> repository) where T : class, IEntity
    {
        var entityFound = FindProductById(repository);
        if (entityFound != null)
        {
            while (true)
            {
                Console.WriteLine($"Do you really want to remove this {typeof(T).Name}?");
                var choice = GetInputFromUserAndReturnString("Press Y if YES\t\tPress N if NO").ToUpper();
                if (choice == "Y")
                {
                    repository.Remove(entityFound);
                    Console.WriteLine($"Your object name:{typeof(T).Name} remove. ");
                    break;
                }
                else if (choice == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose Yes or No:");
                }
            }
        }
    }
    private T? FindProductById<T>(IRepository<T> entityRepository) where T : class, IEntity
    {
        while (true)
        {
            var choiceID = GetInputFromUserAndReturnInt($"Enter the ID of the {typeof(T).Name} you want to find:");

            var entity = entityRepository.GetById(choiceID);
            if (entity != null)
            {
                Console.WriteLine(entity.ToString());
            }
            return entity;
        }
    }
    private void WriteAllToConsole<T>(IRepository<T> repository) where T : class, IEntity
    {
        Console.WriteLine("\nAll products:\n");
        var items = repository.GetAll();
        if (items.ToList().Count == 0)
        {
            Console.WriteLine("\n No objects in Memory, loading from file:\n");
            items = repository.Read();
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    private void AddNewTrailer(IRepository<Trailer> trailerRepository)
    {
        var manufacturer = GetInputFromUserAndReturnString("Insert Location.");

        var year = GetInputFromUserAndReturnInt("Insert year of production.");

        var tonnage = GetInputFromUserAndReturnDouble("Insert tonnage trailer.");

        Trailer trailer = new Trailer
        {
            Manufacturer = manufacturer,
            YearOfProduction = year,
            DateTimeChanges = DateTime.Now,
            Tonnage = tonnage
        };
        trailer.Equipment = new List<Equipment>();
        AddEquipment(trailer.Equipment);

        trailer.OtherEquipment = new List<string>();
        AddOtherEquipment(trailer.OtherEquipment);
        
        trailerRepository.Add(trailer);
        Console.WriteLine("New trailer added");
    }

    private void AddNewFirefightingVehicle(IRepository<FirefightingVehicle> firefightingVehicleRepository)
    {
        var manufacturer = GetInputFromUserAndReturnString("Insert Location");

        var year = GetInputFromUserAndReturnInt("Insert year of production");

        var vehicleCategory = GetValueFromUserAndReturnCorrectInt("Insert vehicle category: 1 - Urban, 2 - MediumOffRoad, 3 - OffRoad");

        var numbersOfSeats = GetInputFromUserAndReturnInt("Insert numbers of seats");

        var weight = GetValueFromUserAndReturnCorrectInt("Insert vehicle category: 1 - Light, 2 - Mediocre, 3 - Heavy");

        var sizeOfWaterReservoir = GetInputFromUserAndReturnDouble("Insert size of water reservoir");

        var sizeOfFoamConcentrateTank = GetInputFromUserAndReturnDouble("Insert size of foam concentrate tank");

        var carPumpEfficiency = GetInputFromUserAndReturnDouble("Insert car pump efficiency");

        var numbersOfFireHoses = GetInputFromUserAndReturnInt("Insert numbers of fire hoses");

        FirefightingVehicle firefightingVehicle = new FirefightingVehicle
        {
            Manufacturer = manufacturer,
            YearOfProduction = year,
            VehicleCategory = (VehicleCategory)vehicleCategory,
            NumbersOfSeats = numbersOfSeats,
            Weight = (Weight)weight,
            DateTimeChanges = DateTime.Now,
            SizeOfWaterReservoir = sizeOfWaterReservoir,
            SizeOfFoamConcentrateTank = sizeOfFoamConcentrateTank,
            CarPumpEfficiency = carPumpEfficiency,
            WaterCannonEfficiency = carPumpEfficiency,
            NumbersOfFireHoses = numbersOfFireHoses,
        };
        firefightingVehicle.Equipment = new List<Equipment>();
        AddEquipment(firefightingVehicle.Equipment);

        firefightingVehicle.OtherEquipment = new List<string>();
        AddOtherEquipment(firefightingVehicle.OtherEquipment);
       
        firefightingVehicleRepository.Add(firefightingVehicle);

        Console.WriteLine("New firefighting vehicle added");
    }

    private void AddNewEmergencyVehicle(IRepository<EmergencyVehicle> emergencyVehicleRepository)
    {
        var manufacturer = GetInputFromUserAndReturnString("Insert Producer");

        var year = GetInputFromUserAndReturnInt("Insert year of production");

        var vehicleCategory = GetValueFromUserAndReturnCorrectInt("Insert vehicle category: 1 - Urban, 2 - MediumOffRoad, 3 - OffRoad");

        var numbersOfSeats = GetInputFromUserAndReturnInt("Insert numbers of seats");

        var weight = GetValueFromUserAndReturnCorrectInt("Insert vehicle category: 1 - Light, 2 - Mediocre, 3 - Heavy");

        EmergencyVehicle emergencyVehicle = new EmergencyVehicle
        {
            Manufacturer = manufacturer,
            YearOfProduction = year,
            VehicleCategory = (VehicleCategory)vehicleCategory,
            NumbersOfSeats = numbersOfSeats,
            Weight = (Weight)weight,
            DateTimeChanges = DateTime.Now
        };
        emergencyVehicle.Equipment = new List<Equipment>();
        AddEquipment(emergencyVehicle.Equipment);
        emergencyVehicle.OtherEquipment = new List<string>();
        AddOtherEquipment(emergencyVehicle.OtherEquipment);
        emergencyVehicleRepository.Add(emergencyVehicle);

        Console.WriteLine("New emergency vehicle added");
    }

    private void AddEquipment(List<Equipment> equipmentAdded) 
    {
        var otherEquipment = GetInputFromUserAndReturnString("Do you want add equipment to car\n Pres Y - yes, N - no")
                                                             .ToUpper();
        
        while (true)
        {
            if (otherEquipment == "Y")
            {
                var userInPut = GetValueFromUserAndReturnCorrectIntEquipment("Insert number : TruckPump = 1," +
                                                     "\r\n MotorPump = 2,\r\n Reservoir = 3," +
                                                     "\r\n WithCO2Cylinders = 4,\r\n FireExtinguishingPowderTank = 5," +
                                                     "\r\n FireHoses = 6,\r\n WithLadder = 7," +
                                                     "\r\n WithHydraulicLift = 8,\r\n Crane  = 9," +
                                                     "\r\n CommandAndCommunications = 10,\r\n Operating = 11," +
                                                     "\r\n Pgaz = 12,\r\n Lighting = 13," +
                                                     "\r\n Quartermaster = 14,\r\n WaterRescue = 15," +
                                                     "\r\n ChemicalRescue = 16,\r\n TechnicalRescue = 17," +
                                                     "\r\n HighAltitudeRescue = 18,\r\n Container = 19,\r\n to exit insert 20");
                equipmentAdded.Add((Equipment)userInPut);
                if (userInPut == 20)
                {
                    break;
                }
            }
            else if (otherEquipment == "N")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please choose Yes or No.");
            }
        }
    }

    private void AddOtherEquipment(List<string> stringList)
    {
        var otherEquipment = GetInputFromUserAndReturnString("Do you want add other equipment to car\n Pres Y - yes, N - no")
                                                             .ToUpper();
        while (true)
        {
            if (otherEquipment == "Y")
            {
                var userInPut = GetInputFromUserAndReturnString("Insert other equipment, to exit insert 'x'");
                stringList.Add(userInPut);
                if (userInPut == "x")
                {
                    break;
                }
            }
            else if (otherEquipment == "N")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please choose Yes or No.");
            }

        }
    }
    protected static int GetValueFromUserAndReturnCorrectIntEquipment(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        var intValue = AddStringConversionToInt(userInput);
        while (true)
        {
            if (intValue >= 1 && intValue <= 20)
            {
                return intValue;
            }
            else
            {
                Console.WriteLine("The uncorrected value.");
                userInput = Console.ReadLine();
                intValue = AddStringConversionToInt(userInput);
            }
        }
    }

    protected static int GetValueFromUserAndReturnCorrectInt(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        while (true)
        {
            if (userInput == "1" || userInput == "2" || userInput == "3")
            {
                var intValue = AddStringConversionToInt(userInput);
                return intValue;
            }
            else
            {
                Console.WriteLine("The uncorrected value.");
            }
        }
    }
}
