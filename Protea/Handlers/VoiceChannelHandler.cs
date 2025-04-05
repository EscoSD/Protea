using Discord.WebSocket;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Handlers;

public class VoiceChannelHandler(DiscordSocketClient client, IVoiceChannelTimerService vcTimerService) : IVoiceChannelHandler
{
	public void InstallHandler()
	{
		client.UserVoiceStateUpdated += HandleUserVoiceStateUpdated;
	}

	private async Task HandleUserVoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		if (user.IsBot) return;

		await CheckUserInChannel(user, before, after);
		CheckUserAfk();
	}

	private async Task CheckUserInChannel(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		if (before.VoiceChannel == null)
        {
        	Console.WriteLine($"{user.Username} ha entrado a un canal de {after.VoiceChannel?.Guild.Name}");
        	vcTimerService.SaveVcEntry(user, after.VoiceChannel!.Guild.Id);

        } else if (after.VoiceChannel == null)
        {
        	Console.WriteLine($"{user.Username} ha salido de un canal de {before.VoiceChannel?.Guild.Name}");
        	await vcTimerService.SaveUserTime(user, before.VoiceChannel!.Guild);
        }
		{
			Console.WriteLine($"{user.Username} ha entrado a un canal de {after.VoiceChannel?.Guild.Name}");
			vcTimerService.SaveVcEntry(new UserGuildDto
			{
				UserId = user.Id,
				GuildId = after.VoiceChannel!.Guild.Id
			});
		}
		else if (after.VoiceChannel == null)
		{
			Console.WriteLine($"{user.Username} ha salido de un canal de {before.VoiceChannel?.Guild.Name}");
			await vcTimerService.SaveUserTime(new UserGuildDto
			{
				UserId = user.Id,
				Username = user.Username,
				GuildId = before.VoiceChannel!.Guild.Id,
				GuildName = before.VoiceChannel.Guild.Name
			});
		}
	}

	private void CheckUserAfk()
	{
		
	}
}