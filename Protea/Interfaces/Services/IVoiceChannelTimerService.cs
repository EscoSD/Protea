using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IVoiceChannelTimerService
{
	void SaveVcEntry(UserGuildDto dto);
	Task SaveUserTime(UserGuildDto dto);
}