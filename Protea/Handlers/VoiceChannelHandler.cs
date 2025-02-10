using Discord.WebSocket;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;

namespace Protea.Handlers;

public class VoiceChannelHandler(DiscordSocketClient client, IVoiceChannelTimerService vcTimerService) : IVoiceChannelHandler
{

	public void InstallHandler()
	{
		client.UserVoiceStateUpdated += HandleUserVoiceStateUpdated;
	}
	
	private async Task HandleUserVoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		if (!user.IsBot && before.VoiceChannel == null)
		{
			Console.WriteLine($"{user.Username} ha entrado a un canal de {after.VoiceChannel?.Guild.Name}");
			vcTimerService.SaveVcEntry(user, after.VoiceChannel!.Guild.Id);

		} else if (!user.IsBot && after.VoiceChannel == null)
		{
			Console.WriteLine($"{user.Username} ha salido de un canal de {before.VoiceChannel?.Guild.Name}");
			await vcTimerService.SaveUserTime(user, before.VoiceChannel!.Guild);
		}
	}
}