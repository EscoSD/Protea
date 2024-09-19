using Discord.WebSocket;
using Protea.Data;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;

namespace Protea.Handlers;

public class VoiceChannelHandler(IVoiceChannelTimerService vctService) : IVoiceChannelHandler
{
	
	public async Task SaveTimeInVoiceChannel(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		if (before.VoiceChannel == null && after.VoiceChannel?.Guild.Id == Constants.OlaBbsGuildId)
		{
			Console.WriteLine($"{user.Username} ha entrado a un canal de OLA BBS");
			vctService.SaveStv(user.Username);
			
		} else if (before.VoiceChannel?.Guild.Id == Constants.OlaBbsGuildId && after.VoiceChannel == null)
		{
			Console.WriteLine($"{user.Username} ha salido de un canal de OLA BBS");
			await vctService.SaveUserTime(user.Username);
		}
	}
}