using Discord.WebSocket;

namespace Protea.Interfaces.Services;

public interface IVoiceChannelTimerService
{
	void SaveVcEntry(SocketUser user, ulong guildId);
	Task SaveUserTime(SocketUser user, SocketGuild guild);
}