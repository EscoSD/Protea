using Discord.Commands;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class AdminCommands(IAdminCommandsService adminCommandsService) : ModuleBase<SocketCommandContext>
{
	[Command(Constants.SleepCommandText)]
	[Summary(Constants.SleepCommandDescription)]
	public async Task EndSessionAsync()
	{
		if (Context.User.Id != Constants.AdminId) return;

		await ReplyAsync(Constants.SleepCommandResponse);
		await adminCommandsService.EndSessionAsync();
	}
	
	[Command(Constants.SwitchGeminiCommandText)]
	[Summary(Constants.SwitchGeminiCommandDescription)]
	public async Task SwitchGeminiAsync()
	{
		if (Context.User.Id != Constants.AdminId) return;
		
		var isEnabled = adminCommandsService.SwitchGemini();

		await ReplyAsync(isEnabled ? Constants.TurnOnGeminiResponse : Constants.TurnOffGeminiResponse);
	}
}