using Json.More;
using Mscc.GenerativeAI;
using Protea.Interfaces.Services;

namespace Protea.Services;

public class GeminiService(GenerativeModel model) : IGeminiService
{
	public async Task<string> GetResponse(string prompt)
	{
		Console.WriteLine(prompt);
		
		var request = new GenerateContentRequest(prompt);
		
		var response = await model.GenerateContent(request);

		if (response.Text == null)
			return $"Ha ocurrido un error.-\\n{response.ToJsonDocument()}";
		
		return response.Text.Length < 1999 ? response.Text :
			"Error: La longitud de la respuesta ha superado lo permitido";
	}
}