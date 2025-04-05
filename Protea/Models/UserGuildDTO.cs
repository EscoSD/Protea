namespace Protea.Models;

public class UserGuildDto
{
	public ulong UserId { get; init; }
	public string? Username { get; init; }
	public ulong GuildId { get; init; }
	public string? GuildName { get; init; }
}