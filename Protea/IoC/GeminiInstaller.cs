using Microsoft.Extensions.DependencyInjection;
using Mscc.GenerativeAI;
using Protea.Data;

namespace Protea.IoC;

public static class GeminiInstaller
{
	public static void InstallGemini(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddSingleton(new GoogleAI(Environment.GetEnvironmentVariable("TOKEN_GEMINI")));
		serviceCollection.AddSingleton<GenerativeModel>(provider =>
		{
			var googleAi = provider.GetRequiredService<GoogleAI>();
			return googleAi.GenerativeModel(
				model: Model.Gemini20Flash,
				systemInstruction: new Content(Constants.GeminiInstruction)
			);
		});
		serviceCollection.AddSingleton<ChatSession>(provider =>
		{
			var model = provider.GetRequiredService<GenerativeModel>();
			return model.StartChat();
		});
	}
}