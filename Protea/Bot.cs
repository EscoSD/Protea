using Discord;
using Discord.WebSocket;
using Protea.Interfaces.Handlers;

namespace Protea;

public class Bot(DiscordSocketClient client, IVoiceChannelHandler vceHandler, ICommandHandler commandHandler, ILogHandler logHandler)
{
	public async Task Run()
	{
		var token = Environment.GetEnvironmentVariable("TOKEN_PROTEA");

		await client.LoginAsync(TokenType.Bot, token);
		await client.StartAsync();

		await commandHandler.InstallCommandsAsync();
		vceHandler.InstallHandler();
		logHandler.InstallHandler();
		
		await Task.Delay(-1);
	}
}
