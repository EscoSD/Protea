using Discord.Commands;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class VcCommands (IVcTimeRecordService vcTimeRecordService): ModuleBase<SocketCommandContext>
{
	[Command(Constants.VcTimeCommandText)]
	[Summary(Constants.VcTimeCommandDesc)]
	public async Task GetVcTimeAsync()
	{
		var response = await vcTimeRecordService
			.GetTimeByIdAsync(Context.Guild.Id, Context.User.Id);
		await ReplyAsync(response);
	}
	
	[Command(Constants.VcRankingCommandText)]
	[Summary(Constants.VcRankingCommandDesc)]
	public async Task GetVcRankingAsync()
	{
		var response = await vcTimeRecordService.GetRankingAsync();
		await ReplyAsync(response);
	}
}