using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IVcTimeRecordService
{
	Task UpdateAsync(VcEntryRecord entryRecord);
	Task<string> GetGuildUserVcTimeById(ulong guildId, ulong userId);
}