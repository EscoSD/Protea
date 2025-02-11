using Discord.Commands;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class UtilCommands(IUtilCommandsService utilCommandsService) : ModuleBase<SocketCommandContext>
{
	[Command(Constants.SleepCommandText)]
	[Summary(Constants.SleepCommandDesc)]
	public async Task EndSessionAsync()
	{
		if (Context.User.Id == Constants.AdminId)
			await utilCommandsService.EndSessionAsync();
	}
}