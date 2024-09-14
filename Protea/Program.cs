// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Protea;
using Protea.IoC;

Console.WriteLine($"{DateTime.Now} - Iniciando Protea");

IServiceCollection services = new ServiceCollection();

services.InstallServices();

IServiceProvider serviceProvider = services.BuildServiceProvider();

var protea = serviceProvider.GetService<Bot>()!;

await protea.Run();
