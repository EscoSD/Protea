using Discord.WebSocket;

namespace Protea.Interfaces.Services;

public interface IUserService
{
	Task UpdateAsync(SocketUser user);
}