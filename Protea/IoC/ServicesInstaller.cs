using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Protea.Handlers;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;
using Protea.Services;

namespace Protea.IoC;

public static class ServicesInstaller
{
	public static void InstallServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddSingleton<Bot>();
		serviceCollection.AddSingleton<DiscordSocketClient>();
		serviceCollection.AddSingleton<CommandService>();
		serviceCollection.AddSingleton<IVoiceChannelTimerService, VoiceChannelTimerService>();
		serviceCollection.AddSingleton<IVoiceChannelHandler, VoiceChannelHandler>();
		serviceCollection.AddSingleton<ICommandHandler, CommandHandler>();
		serviceCollection.AddSingleton<ILogHandler, LogHandler>();
		serviceCollection.AddSingleton<IUserService, UserService>();
		serviceCollection.AddSingleton<IGuildService, GuildService>();
		serviceCollection.AddSingleton<IVcTimeRecordService, VcTimeRecordService>();
		serviceCollection.AddSingleton<IUtilCommandsService, UtilCommandsService>();

		serviceCollection.AddHttpClient<IHttpService, HttpService>();
	}
}