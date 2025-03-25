using Discord;

namespace Protea.Interfaces.Services;

public interface IUtilCommandsService
{
	Task EndSessionAsync();
	List<EmbedFieldBuilder> GetAllCommandFields();
}