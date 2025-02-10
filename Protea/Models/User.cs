using System.ComponentModel.DataAnnotations;

namespace Protea.Models;

public class User
{
    public ulong Id { get; init; }

    [MaxLength(50)]
    public string Username { get; init; } = null!;

    public virtual ICollection<VcTimeRecord> GuildUsers { get; init; } = new List<VcTimeRecord>();
}
