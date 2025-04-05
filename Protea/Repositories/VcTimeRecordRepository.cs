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
				g.GuildId == guildId && g.UserId == userId);
	}

	public async Task<IEnumerable<VcTimeRecordDto>> GetRankingAsync(ulong guildId)
	{
		FormattableString query =
			$"""
			                   SELECT U.Username, V.TimeSpentMilliseconds
			                   FROM VcTimeRecord V 
			                       INNER JOIN User U 
			                           ON V.UserId = U.Id
			                   WHERE GuildId = {guildId}
			                   ORDER BY TimeSpentMilliseconds DESC
			                   LIMIT 5;
			 """;

		return await context.Database.SqlQuery<VcTimeRecordDto>(query).ToListAsync();
	}

	public async Task Update(VcTimeRecord vcTimeRecord)
	{
		context.GuildUsers.Update(vcTimeRecord);
		await context.SaveChangesAsync();
	}
}