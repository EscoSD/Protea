using Discord;
using Discord.Commands;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Modules;

public class MiscCommands(IMiscCommandsService miscCommandsService, IHttpService httpService) : ModuleBase<SocketCommandContext>
{
	[Command(Constants.HelpCommandText)]
	[Summary(Constants.HelpCommandDescription)]
	public async Task HelpAsync()
	{
		var embed = new EmbedBuilder
		{
			Title = "Comandos",
			Fields = miscCommandsService.GetAllCommandFields(),
			Color = Color.Green
		}.Build();
		
		await ReplyAsync(embed: embed);
	}
	
	[Command(Constants.CatMeCommandText)]
	[Summary(Constants.CatMeCommandDescription)]
	public async Task CatMeAsync()
	{
		var embed = new EmbedBuilder
		{
			Title = "GATO",
			ImageUrl = await httpService.GetCatUrlAsync(),
			Color = Color.Green
		}.Build();
		
		await ReplyAsync(embed: embed);
	}
	
	[Command(Constants.DogMeCommandText)]
	[Summary(Constants.DogMeCommandDescription)]
	public async Task DogMeAsync()
	{
		var embed = new EmbedBuilder
		{
			Title = "ola",
			ImageUrl = await httpService.GetDogUrlAsync(),
			Color = Color.Green
		}.Build();
		
		await ReplyAsync(embed: embed);
	}
	
	[Command(Constants.PigCommandText)]
	[Summary(Constants.PigCommandDescription)]
	public async Task PigMeAsync()
	{
		var embed = new EmbedBuilder
		{
			Title = "ola",
			ImageUrl = Constants.PigImgUrl,
			Color = Color.Green
		}.Build();
		
		await ReplyAsync(embed: embed);
	}
	
	[Command(Constants.JakeCommandText)]
	[Summary(Constants.JakeCommandDescription)]
	public async Task JaketeameAsync()
	{
		var embed = new EmbedBuilder
		{
			Title = "ola",
			ImageUrl = Constants.JakeImgUrl,
			Color = Color.Green
		}.Build();
		
		await ReplyAsync(embed: embed);
	}
}