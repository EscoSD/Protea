using Protea.Models;

namespace Protea.Interfaces.Repositories;

public interface IVcTimeRecordRepository
{
	Task AddAsync(VcTimeRecord vcTimeRecord);
	Task<VcTimeRecord?> GetByIdAsync(ulong guildId, ulong userId);
	Task Update(VcTimeRecord vcTimeRecord);
	Task<IEnumerable<VcTimeRecordDto>> GetRankingAsync(ulong guildId);
}