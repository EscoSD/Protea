namespace Protea.Models;

// Modelo para el archivo de registro de tiempo pasado en un canal de voz.
public class TimeSpentVc
{
	public ulong UserId { get; init; }
	public string? Username { get; init; }
	public ulong GuildId { get; init; }
	public string? GuildName { get; init; }
	public long TimeSpentMilliseconds { get; set; }
}
