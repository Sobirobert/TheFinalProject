using FireTrucks._5_Components.DataProviders;

namespace FireTrucks._2_ApplicationServices;

public class AdditionalInfoProviderFirefightingVehicle : UserCommunicationBase, IAdditionalInfoProviderFirefighterVehicle
{
    private readonly IFirefightingVehicleProvider _firefightingVehicleProvider;

    public AdditionalInfoProviderFirefightingVehicle(IFirefightingVehicleProvider firefightingVehicleProvider)
    {
        _firefightingVehicleProvider = firefightingVehicleProvider;
    }

    public void MenuFirefighterVehicle()
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
                    OrderBySizeOfWaterReservoir();
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
        var names = _firefightingVehicleProvider.OrderByManufacturerDescending();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void OrderByYearOfProductionDescending()
    {
        var names = _firefightingVehicleProvider.OrderByYearOfProductionDescending();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void OrderByNumbersOfSeats()
    {
        var names = _firefightingVehicleProvider.OrderByNumbersOfSeats();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public void OrderBySizeOfWaterReservoir()
    {
        var names = _firefightingVehicleProvider.OrderBySizeOfWaterReservoir();
        foreach (var name in names)
        {
            Console.WriteLine($" Your min size of water reservoir: {name}");
        }
    }

    public void FindVehicleWhereWeightIsLikeUserChose()
    {
        var names = _firefightingVehicleProvider.FindVehicleWhereWeightIsLikeUserChose();
        foreach (var name in names)
        {
            Console.WriteLine($" Your min count product is: {name}");
        }
    }
}