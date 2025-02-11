using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using Protea.Data;
using Protea.Interfaces.Handlers;

namespace Protea.Handlers;

public class CommandHandler(IServiceProvider services, DiscordSocketClient client, CommandService commands) : ICommandHandler
{
	public async Task InstallCommandsAsync()
	{
		client.MessageReceived += HandleCommandAsync;
		await commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
			services: services);
	}

	private async Task HandleCommandAsync(SocketMessage messageParam)
	{
		if (messageParam is not SocketUserMessage message)
			return;
		
		var argPos = 0;
		
		if (!(message.HasCharPrefix(Constants.CommandsPrefix, ref argPos) ||
		      message.HasMentionPrefix(client.CurrentUser, ref argPos)) ||
		    message.Author.IsBot)
			return;
		
		var context = new SocketCommandContext(client, message);
		
		await commands.ExecuteAsync(
			context: context,
			argPos: argPos,
			services: services);
	}
}