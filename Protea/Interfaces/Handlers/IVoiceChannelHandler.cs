using Discord.WebSocket;

namespace Protea.Interfaces.Handlers;

public interface IVoiceChannelHandler
{
	Task SaveTimeInVoiceChannel(SocketUser user, SocketVoiceState before, SocketVoiceState after);
}