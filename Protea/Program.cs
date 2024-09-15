// See https://aka.ms/new-console-template for more information

using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Protea;
using Protea.IoC;
using Protea.Models.Configuration;

Console.WriteLine($"{DateTime.Now} - Iniciando Protea");

IServiceCollection services = new ServiceCollection();

var config = new ConfigurationApp().SetConfig();
var discConfig = new DiscordSocketConfig
{
	GatewayIntents = GatewayIntents.All
};

services.InstallConfig(config, discConfig);
services.InstallServices();

IServiceProvider serviceProvider = services.BuildServiceProvider();

var protea = serviceProvider.GetService<Bot>()!;

await protea.Run();
