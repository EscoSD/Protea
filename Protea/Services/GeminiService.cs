using Json.More;
using Mscc.GenerativeAI;
using Protea.Interfaces.Services;

namespace Protea.Services;

public class GeminiService(ChatSession chat) : IGeminiService
{
	public async Task<string> GetResponse(string prompt)
	{
		if (chat.History.Count > 200)
			chat.History.RemoveRange(0, 50);
		
		var response = await chat.SendMessage(prompt);

		return response.Text ??
		       $"Ha ocurrido un error.-\\n{response.ToJsonDocument()}";
	}
}