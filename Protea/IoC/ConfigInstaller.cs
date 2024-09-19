using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Protea.Models.Configuration;

namespace Protea.IoC;

public static class ConfigInstaller
{
	public static void InstallConfig(this IServiceCollection serviceCollection, ConfigurationApp config, DiscordSocketConfig discConfig, CommandServiceConfig commandsConfig)
	{
		serviceCollection.AddSingleton(config);
		serviceCollection.AddSingleton(discConfig);
		serviceCollection.AddSingleton(commandsConfig);
	}
}