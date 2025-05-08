namespace Protea.Interfaces.Handlers;

public interface IMentionHandler
{
	bool IsGeminiEnabled { get; set; }
	void InstallHandler();
}