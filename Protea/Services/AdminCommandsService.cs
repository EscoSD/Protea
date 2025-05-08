using Discord.WebSocket;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;

namespace Protea.Services;

public class AdminCommandsService(DiscordSocketClient client, IMentionHandler mentionHandler) : IAdminCommandsService
{
	public async Task EndSessionAsync()
	{
		// TODO Usar Cancellation Token Source
		await client.StopAsync();
		Environment.Exit(0);
	}

	public bool SwitchGemini()
	{
		return mentionHandler.IsGeminiEnabled ^= true;
	}
}