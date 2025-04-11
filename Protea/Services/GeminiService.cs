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

		if (response.Text == null)
			return $"Ha ocurrido un error.-\\n{response.ToJsonDocument()}";
		
		return response.Text.Length < 1999 ? response.Text :
			"Error: La longitud de la respuesta ha superado lo permitido";
	}
}