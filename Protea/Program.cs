// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Protea;
using Protea.IoC;
using Protea.Models.Configuration;

Console.WriteLine($"{DateTime.Now} - Iniciando Protea");

IServiceCollection services = new ServiceCollection();
var config = new ConfigurationApp().SetConfig();

services.InstallServices();
services.InstallConfig(config);

IServiceProvider serviceProvider = services.BuildServiceProvider();

var protea = serviceProvider.GetService<Bot>()!;

await protea.Run();
