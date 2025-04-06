using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IVcTimeRecordService
{
	Task UpdateAsync(VcEntryRecord entryRecord);
	Task<string> GetTimeByIdAsync(ulong guildId, ulong userId);
	Task<string> GetRankingAsync(ulong guildId);
}