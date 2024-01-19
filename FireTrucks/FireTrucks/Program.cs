using FireTrucks._1_DataAccess;
using FireTrucks._1_DataAccess.Entities;
using FireTrucks._1_DataAccess.Repositories;
using FireTrucks._2_ApplicationServices;
using FireTrucks._3_UI;
using FireTrucks._5_Components.CsvReader;
using FireTrucks._5_Components.DataProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<EmergencyVehicle>, SqlRepository<EmergencyVehicle>>();
services.AddSingleton<IRepository<FirefightingVehicle>, SqlRepository<FirefightingVehicle>>();
services.AddSingleton<IRepository<Trailer>, SqlRepository<Trailer>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerServices, EventHandlerServices>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IDataProvider, DataProvider>();
services.AddSingleton<IEmergencyVehicleProvider, EmergencyVehicleProvider>();
services.AddSingleton<IFirefightingVehicleProvider, FirefightingVehicleProvider>();
services.AddSingleton<IAdditionalInfoProviderEmergencyVehicle, AdditionalInfoProviderEmergencyVehicle>();
services.AddSingleton<IAdditionalInfoProviderFirefighterVehicle, AdditionalInfoProviderFirefightingVehicle>();
services.AddDbContext<FireTrucksDbContext>(options => options
.UseSqlServer("Data Source=DESKTOP-7S5NEGF\\SQLEXPRESS;Initial Catalog=FireTrucks;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));
var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>()!;
app.Run();