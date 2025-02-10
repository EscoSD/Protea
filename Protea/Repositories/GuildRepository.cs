using Microsoft.EntityFrameworkCore;
using Protea.Context;
using Protea.Interfaces.Repositories;
using Protea.Models;

namespace Protea.Repositories;

public class GuildRepository(ProteaContext context) : IGuildRepository
{
	public async Task AddAsync(Guild guild)
	{
		await context.Guilds.AddAsync(guild);
		await context.SaveChangesAsync();
	}

	public async Task<Guild?> GetByIdAsync(ulong id)
	{
		return await context.Guilds.FirstOrDefaultAsync(g => g.Id == id);
	}

	public async Task UpdateAsync(Guild guild)
	{
		context.Guilds.Update(guild);
		await context.SaveChangesAsync();
	}
}