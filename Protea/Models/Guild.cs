using System.ComponentModel.DataAnnotations;

namespace Protea.Models;

public class Guild
{
    public ulong Id { get; init; }
    
    [MaxLength(50)]
    public string Name { get; init; } = null!;

    public virtual ICollection<VcTimeRecord> GuildUsers { get; init; } = new List<VcTimeRecord>();
}
