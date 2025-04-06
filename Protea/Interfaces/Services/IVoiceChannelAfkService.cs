using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IVoiceChannelAfkService
{
	Task UserSelfDeafened(UserGuildDto dto);
	void UserSelfUndeafened(UserGuildDto dto);
}