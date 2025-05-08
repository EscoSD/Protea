namespace Protea.Interfaces.Services;

public interface IAdminCommandsService
{
	Task EndSessionAsync();
	bool SwitchGemini();
}