namespace Protea.Interfaces.Services;

public interface IGeminiService
{
	Task<string> GetResponse(string prompt);
}