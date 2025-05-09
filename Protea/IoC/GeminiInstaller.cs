using Microsoft.Extensions.DependencyInjection;
using Mscc.GenerativeAI;
using Protea.Models.Configuration;

namespace Protea.IoC;

public static class GeminiInstaller
{
	public static void InstallGemini(this IServiceCollection serviceCollection, ConfigurationApp config)
	{
		serviceCollection.AddSingleton(new GoogleAI(Environment.GetEnvironmentVariable("TOKEN_GEMINI")));
		serviceCollection.AddSingleton<GenerativeModel>(provider =>
		{
			var googleAi = provider.GetRequiredService<GoogleAI>();

			return googleAi.GenerativeModel(
				model: Model.Gemini20Flash,
				systemInstruction: new Content(config.GeminiSystemInstruction ??
				                               throw new InvalidOperationException(
					                               "Gemini System Instruction not found."))
			);
		});
		serviceCollection.AddSingleton<ChatSession>(provider =>
		{
			var model = provider.GetRequiredService<GenerativeModel>();
			return model.StartChat();
		});
	}
}