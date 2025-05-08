using Discord;
using Protea.Data;
using Protea.Interfaces.Services;

namespace Protea.Services;

public class MiscCommandsService : IMiscCommandsService
{
	public List<EmbedFieldBuilder> GetAllCommandFields()
	{
		var commands = new Dictionary<string, string>
		{
			{Constants.HelpCommandText, Constants.HelpCommandDescription},
			{Constants.VcTimeCommandText, Constants.VcTimeCommandDescription},
			{Constants.VcRankingCommandText, Constants.VcRankingCommandDescription},
			{Constants.CatMeCommandText, Constants.CatMeCommandDescription},
			{Constants.DogMeCommandText, Constants.DogMeCommandDescription},
			{Constants.PigCommandText, Constants.PigCommandDescription}
		};

		return commands.Select(keyValuePair => 
			new EmbedFieldBuilder { Name = $"¿{keyValuePair.Key}", Value = keyValuePair.Value })
			.ToList();
	}
}