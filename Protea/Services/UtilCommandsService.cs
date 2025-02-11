using Discord.WebSocket;
using Protea.Interfaces.Services;

namespace Protea.Services;

public class UtilCommandsService(DiscordSocketClient client) : IUtilCommandsService
{
	public async Task EndSessionAsync()
	{
		await client.StopAsync();
		Environment.Exit(0);
	}
}