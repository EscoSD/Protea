using Discord;
using Discord.WebSocket;
using Protea.Interfaces.Handlers;

namespace Protea.Handlers;

public class LogHandler (DiscordSocketClient client): ILogHandler
{
	public void InstallHandler()
	{
		client.Log += LogDiscordMsg;
	}
	
	private static Task LogDiscordMsg(LogMessage msg)
	{
		// TODO añadir log a fichero
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}
}