using Discord.Commands;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class Commands (IVcTimeRecordService vcTimeRecordService): ModuleBase<SocketCommandContext>
{
	[Command("vcTime")]
	[Summary(Constants.VcTimeCommandDesc)]
	public async Task GetVcTimeAsync()
	{
		var response = await vcTimeRecordService
			.GetTimeByIdAsync(Context.Guild.Id, Context.User.Id);
		await ReplyAsync(response);
	}
	
	[Command("vcRanking")]
	[Summary(Constants.VcRankingCommandDesc)]
	public async Task GetVcRankingAsync()
	{
		var response = await vcTimeRecordService.GetRankingAsync();
		await ReplyAsync(response);
	}
}