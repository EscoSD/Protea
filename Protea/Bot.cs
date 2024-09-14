using Discord;
using Discord.WebSocket;
using Protea.Interfaces.Services;

namespace Protea;

public class Bot(DiscordSocketClient client, IVoiceChannelEventHandler vceHandler)
{
	public async Task Run()
	{
		client.Log += Log;
		client.UserVoiceStateUpdated += UserVoiceStateUpdatedAsync;
		
		var token = Environment.GetEnvironmentVariable("TOKEN_PROTEA");

		await client.LoginAsync(TokenType.Bot, token);
		await client.StartAsync();

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
