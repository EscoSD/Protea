using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Protea;
using Protea.IoC;
using Protea.Models.Configuration;

Console.WriteLine($"{DateTime.Now} - Iniciando Protea");

IServiceCollection services = new ServiceCollection();

var config = new ConfigurationApp().SetConfig();
var discConfig = new DiscordSocketConfig().GetClientConfig();
var commandsConfig = new CommandServiceConfig().GetCommandsConfig();

services.InstallConfig(config, discConfig, commandsConfig);
services.InstallContext(config);
services.InstallRepositories();
services.InstallServices();

IServiceProvider serviceProvider = services.BuildServiceProvider();

var protea = serviceProvider.GetService<Bot>()!;

await protea.Run();
