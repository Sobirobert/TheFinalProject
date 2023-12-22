using FireTrucks._3_UI;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>()!;
app.Run();