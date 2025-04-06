using Discord;
using Discord.Commands;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class VcCommands (IVcTimeRecordService vcTimeRecordService, IHttpService httpService): ModuleBase<SocketCommandContext>
{
	[Command(Constants.VcTimeCommandText)]
	[Summary(Constants.VcTimeCommandDescription)]
	public async Task GetVcTimeAsync()
	{
		var response = await vcTimeRecordService
			.GetTimeByIdAsync(Context.Guild.Id, Context.User.Id);
		
		var embed = new EmbedBuilder
		{
			Title = Constants.VcTimeCommandTitle,
			Description = response,
			Color = Color.Green
		}.Build();
		
		await ReplyAsync(embed: embed);
	}
	
	[Command(Constants.VcRankingCommandText)]
	[Summary(Constants.VcRankingCommandDescription)]
	public async Task GetVcRankingAsync()
	{
		var response = await vcTimeRecordService.GetRankingAsync(Context.Guild.Id);

		var imgUrl = await httpService.GetCatUrlAsync();
		
		var embed = new EmbedBuilder
		{
			Title = Constants.VcRankingCommandTitle,
			Url = Constants.VcRankingTitleUrl,
			Description = response,
			Color = Color.Green,
			ImageUrl = imgUrl
		}.Build();
		
		await ReplyAsync(embed: embed);
	}
}