using Discord.Commands;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class Commands (IJsonService jsonService): ModuleBase<SocketCommandContext>
{
	[Command("vcTime")]
	[Summary(Constants.VcTimeCommandDesc)]
	public async Task GetVcTimeAsync()
	{
		var response = await jsonService.GetUserTimeAsync(Context.User.Username);
		await ReplyAsync(response);
	}
	
	[Command("vcRanking")]
	[Summary(Constants.VcRankingCommandDesc)]
	public async Task GetVcRankingAsync()
	{
		var response = await jsonService.GetVcRankingAsync();
		await ReplyAsync(response);
	}
}