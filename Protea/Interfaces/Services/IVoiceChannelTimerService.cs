namespace Protea.Interfaces.Services;

public interface IVoiceChannelTimerService
{
	void SaveStv(string username);
	void SaveUserTime(string username);
}