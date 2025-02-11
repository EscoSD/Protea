namespace Protea.Models;

public class VcTimeRecord
{
    public ulong GuildId { get; init; }

    public ulong UserId { get; init; }

    public ulong TimeSpentMilliseconds { get; set; }

    public virtual Guild Guild { get; init; } = null!;

    public virtual User User { get; init; } = null!;
}
