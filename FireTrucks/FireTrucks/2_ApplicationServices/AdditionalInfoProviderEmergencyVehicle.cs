using FireTrucks._5_Components.DataProviders;

namespace FireTrucks._2_ApplicationServices;

public class AdditionalInfoProviderEmergencyVehicle : UserCommunicationBase, IAdditionalInfoProviderEmergencyVehicle 
{
    private readonly IEmergencyVehicleProvider _emergencyVehicleProvider;

    public AdditionalInfoProviderEmergencyVehicle(IEmergencyVehicleProvider emergencyVehicleProvider)
    {
        _emergencyVehicleProvider = emergencyVehicleProvider;
    }

    public void MenuEmergencyVehicle()
    {
        while (true)
        {
            Console.WriteLine(
                "--- WHAT KIND OF INFORMATION YOU WANT TO VIEW ---\n" +
                "1 - Order by manufacturer descending\n" +
                "2 - Order by year of production descending\n" +
                "3 - Order by numbers of seats \n" +
                "4 - Select fridge location fridge\n" +
                "5 - Find vehicles where weight is heavy\n" +
                "X - Back to MAIN MENU\n");

            var userInput = GetInputFromUserAndReturnString("What you want to do? \n").ToUpper();

            switch (userInput)
            {
                case "1":
                    OrderByManufacturerDescending();
                    break;

                case "2":
                    OrderByYearOfProductionDescending();
                    break;

                case "3":
                    OrderByNumbersOfSeats();
                    break;

                case "4":
                    OrderBySizeVehicleCategory();
                    break;

                case "5":
                    FindVehicleWhereWeightIsLikeUserChose();
                    break;

                case "X":
                    return;

                default:
                    Console.WriteLine("Invalid operation.\n");
                    continue;
            }
        }
    }

    private void OrderByManufacturerDescending()
    {
        var names = _emergencyVehicleProvider.OrderByManufacturerDescending();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void OrderByYearOfProductionDescending()
    {
        var names = _emergencyVehicleProvider.OrderByYearOfProductionDescending();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void OrderByNumbersOfSeats()
    {
        var names = _emergencyVehicleProvider.OrderByNumbersOfSeatsThanByWeight();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public void OrderBySizeVehicleCategory()
    {
        var names = _emergencyVehicleProvider.OrderByWeightVehicleCategoryThanByCategory();
        foreach (var name in names)
        {
            Console.WriteLine($" Your min count product is: {name}");
        }
    }

    public void FindVehicleWhereWeightIsLikeUserChose()
    {
        var names = _emergencyVehicleProvider.FindVehicleWhereWeightIsLikeUserChose();
        foreach (var name in names)
        {
            Console.WriteLine($" Your min count product is: {name}");
        }
    }
}