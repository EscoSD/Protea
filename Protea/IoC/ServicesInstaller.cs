using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Protea.Interfaces.Services;
using Protea.Services;

namespace Protea.IoC;

public static class ServicesInstaller
{
	public static void InstallServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddSingleton<Bot>();
		serviceCollection.AddSingleton<DiscordSocketClient>();
		serviceCollection.AddSingleton<IVoiceChannelTimerService, VoiceChannelTimerService>();
		serviceCollection.AddSingleton<IVoiceChannelEventHandler, VoiceChannelEventHandler>();
		serviceCollection.AddSingleton<IJsonService, JsonService>();
	}
}