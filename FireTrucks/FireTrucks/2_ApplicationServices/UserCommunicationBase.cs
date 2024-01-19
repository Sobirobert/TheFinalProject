namespace FireTrucks._2_ApplicationServices;

public abstract class UserCommunicationBase
{
    protected static int GetInputFromUserAndReturnInt(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        var userInPutInt = AddStringConversionToInt(userInput);
        return userInPutInt;
    }

    protected static int GetInputFromUserAndReturnIntNoGreaterThan3(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        while (true)
        {
            if (userInput == "1" || userInput == "2" || userInput == "3")
            {
                Console.WriteLine("Correct value.");
                break;
            }
            else
            {
                Console.WriteLine("Wrong number! Insert correct value.");
                userInput = Console.ReadLine();
                break;
            }
            
        }
        var userInPutInt = AddStringConversionToInt(userInput);
        return userInPutInt;
    }

    protected static string GetInputFromUserAndReturnString(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        return userInput;
    }

    protected static double GetInputFromUserAndReturnDouble(string comment)
    {
        Console.WriteLine(comment);
        var userInput = Console.ReadLine();
        var doubleValue = AddStringConversionToDouble(userInput);
        return doubleValue;
    }

    protected static int AddStringConversionToInt(string value)
    {
        if (int.TryParse(value, out int number))
        {
            Console.WriteLine("The conversion success.");
        }
        else
        {
            Console.WriteLine("The conversion wasn't successful.");
        }
        return number;
    }

    protected static double AddStringConversionToDouble(string value)
    {
        if (int.TryParse(value, out int number))
        {
            Console.WriteLine("The conversion success.");
        }
        else
        {
            Console.WriteLine("The conversion wasn't successful.");
        }
        return number;
    }
}