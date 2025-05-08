using Discord;

namespace Protea.Interfaces.Services;

public interface IMiscCommandsService
{
	List<EmbedFieldBuilder> GetAllCommandFields();
}