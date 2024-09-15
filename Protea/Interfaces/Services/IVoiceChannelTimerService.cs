namespace Protea.Interfaces.Services;

public interface IVoiceChannelTimerService
{
	void SaveStv(string username);
	Task SaveUserTime(string username);
}