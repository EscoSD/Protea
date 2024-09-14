using Discord.WebSocket;

namespace Protea.Interfaces.Services;

public interface IVoiceChannelEventHandler
{
	Task SaveTimeInVoiceChannel(SocketUser user, SocketVoiceState before, SocketVoiceState after);
}