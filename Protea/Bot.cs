using Discord;
using Discord.WebSocket;
using Protea.Interfaces.Handlers;

namespace Protea;

public class Bot(DiscordSocketClient client, IVoiceChannelHandler vceHandler, ICommandHandler commandHandler)
{
	public async Task Run()
	{
		client.Log += Log;
		client.UserVoiceStateUpdated += UserVoiceStateUpdatedAsync;
		
		var token = Environment.GetEnvironmentVariable("TOKEN_PROTEA");

		await client.LoginAsync(TokenType.Bot, token);
		await client.StartAsync();

		await commandHandler.InstallCommandsAsync();

		// Block this task until the program is closed.
		await Task.Delay(-1);
	}

	private Task UserVoiceStateUpdatedAsync(SocketUser user, SocketVoiceState before, SocketVoiceState after)
		=> vceHandler.SaveTimeInVoiceChannel(user, before, after);
	
	private static Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}
}
