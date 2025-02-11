namespace Protea.Models;

// Clase para guardar el momento de entrada a un canal de voz.
public class VcEntryRecord
{
	public ulong UserId { get; init; }
	public ulong GuildId { get; init; }
	public DateTime StartTime { get; init; }
}