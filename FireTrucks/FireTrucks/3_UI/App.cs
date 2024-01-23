using FireTrucks._2_ApplicationServices;

namespace FireTrucks._3_UI;

public class App : IApp
{
    private readonly IEventHandlerServices _eventHandlerService;
    private readonly IUserCommunication _userCommunication;


    public App(IEventHandlerServices eventHandlerService, IUserCommunication userCommunication)
    {
        _eventHandlerService = eventHandlerService;
        _userCommunication = userCommunication;
    }

    public void Run()
    {
        _eventHandlerService.SubscribeToEvents();
        _userCommunication.Menu();
    }
}