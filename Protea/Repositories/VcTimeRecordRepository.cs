using Microsoft.EntityFrameworkCore;
using Protea.Context;
using Protea.Interfaces.Repositories;
using Protea.Models;

namespace Protea.Repositories;

public class VcTimeRecordRepository(ProteaContext context) : IVcTimeRecordRepository
{
	public async Task AddAsync(VcTimeRecord vcTimeRecord)
	{
		await context.GuildUsers.AddAsync(vcTimeRecord);
		await context.SaveChangesAsync();
	}

	public async Task<VcTimeRecord?> GetByIdAsync(ulong guildId, ulong userId)
	{
		return await context.GuildUsers
			.FirstOrDefaultAsync(g =>
				g.GuildId == guildId || g.UserId == userId);
	}

	public async Task Update(VcTimeRecord vcTimeRecord)
	{
		context.GuildUsers.Update(vcTimeRecord);
		await context.SaveChangesAsync();
	}
}