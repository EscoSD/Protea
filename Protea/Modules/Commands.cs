using Discord.Commands;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class Commands (IJsonService jsonService): ModuleBase<SocketCommandContext>
{
	[Command("vcTime")]
	[Summary("Revela el tiempo que has pasado en canales de voz dentro de este servidor.")]
	public async Task GetVcTimeAsync()
	{
		var response = await jsonService.GetUserTimeAsync(Context.User.Username);
		await ReplyAsync(response);
	}
	
	[Command("vcRanking")]
	[Summary("Muestra un ranking con los tiempos pasados en VCs.")]
	public async Task GetVcRankingAsync()
	{
		var response = await jsonService.GetVcRankingAsync();
		await ReplyAsync(response);
	}
}