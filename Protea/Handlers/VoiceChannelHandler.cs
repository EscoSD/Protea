using Discord.WebSocket;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Handlers;

public class VoiceChannelHandler(
	DiscordSocketClient client,
	IVoiceChannelTimerService vcTimerService,
	IVoiceChannelAfkService vcAfkService)
	: IVoiceChannelHandler
{
	public void InstallHandler()
	{
		client.UserVoiceStateUpdated += HandleUserVoiceStateUpdated;
	}

	private async Task HandleUserVoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		if (user.IsBot) return;
		
		await CheckUserInChannel(user, before, after);
		await CheckUserAfk(user, before, after);
	}

	private async Task CheckUserInChannel(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		if (before.VoiceChannel == null)
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

	private Task CheckUserAfk(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		switch (before.IsSelfDeafened)
		{
			case false when after is { IsSelfDeafened: true, VoiceChannel: not null }:
				Console.WriteLine($"{user.Username} se ha ensordecido");
				_ = vcAfkService.UserSelfDeafened(new UserGuildDto
				{
					UserId = user.Id,
					Username = user.Username,
					GuildId = after.VoiceChannel.Guild.Id,
					GuildName = after.VoiceChannel.Guild.Name
				});
				break;
			case true when !after.IsSelfDeafened:
				Console.WriteLine($"{user.Username} ya no está ensordecido");
				vcAfkService.UserSelfUndeafened(new UserGuildDto
				{
					UserId = user.Id,
					GuildId = after.VoiceChannel!.Guild.Id
				});
				break;
		}

		return Task.CompletedTask;
	}
}