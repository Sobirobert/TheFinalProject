using FireTrucks._1_DataAccess;
using FireTrucks._1_DataAccess.Entities;
using FireTrucks._2_ApplicationServices;
using FireTrucks._5_Components.CsvReader;
using FireTrucks._5_Components.DataProviders;

namespace FireTrucks._3_UI;

public class App : IApp
{
    private readonly IEventHandlerServices _eventHandlerService;
    private readonly IUserCommunication _userCommunication;
    private readonly IDataProvider _dataProvider;


    public App(IEventHandlerServices eventHandlerService, IUserCommunication userCommunication, IDataProvider dataProvider)
    {
        _eventHandlerService = eventHandlerService;
        _userCommunication = userCommunication;
        _dataProvider = dataProvider;
    }

    public void Run()
    {
        //_dataProvider.AdditionalVehicleInfoProvider();
        _eventHandlerService.SubscribeToEvents();
        _userCommunication.Menu();
    }
}