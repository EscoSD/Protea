using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Protea.Models.Configuration;

namespace Protea.IoC;

public static class AppConfigSetter
{
	public static ConfigurationApp SetConfig(this ConfigurationApp model)
	{
		using var config = new ConfigurationManager();
		config.AddJsonFile("appsettings.json");

		config.GetSection("ConfigurationApp").Bind(model);

		return model;
	}
	
	public static DiscordSocketConfig GetClientConfig(this DiscordSocketConfig config)
	{
		config.GatewayIntents = GatewayIntents.All;
		return config;
	}

	public static CommandServiceConfig GetCommandsConfig(this CommandServiceConfig config)
	{
		config.CaseSensitiveCommands = false;
		config.LogLevel = LogSeverity.Info;
		
		return config;
	}
}