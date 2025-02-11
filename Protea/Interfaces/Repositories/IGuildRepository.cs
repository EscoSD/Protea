using Protea.Models;

namespace Protea.Interfaces.Repositories;

public interface IGuildRepository
{
	Task AddAsync(Guild guild);
	Task<Guild?> GetByIdAsync(ulong id);
	Task UpdateAsync(Guild guild);
}