using Discord.WebSocket;

namespace Protea.Interfaces.Services;

public interface IGuildService
{
	Task UpdateAsync(SocketGuild guild);
}