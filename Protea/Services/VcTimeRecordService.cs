using Protea.Data;
using Protea.Interfaces.Repositories;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class VcTimeRecordService(IVcTimeRecordRepository vcTimeRecordRepository) : IVcTimeRecordService
{
	public async Task UpdateAsync(VcEntryRecord entryRecord)
	{
		var userVcTimeRecord = await vcTimeRecordRepository
			.GetByIdAsync(entryRecord.GuildId, entryRecord.UserId);
		
		var newGuildUser = new VcTimeRecord
		{
			GuildId = entryRecord.GuildId,
			UserId = entryRecord.UserId,
			TimeSpentMilliseconds = Convert.ToUInt64(
				(DateTime.Now - entryRecord.StartTime).TotalMilliseconds),
		};
		
		if (userVcTimeRecord == null)
			await vcTimeRecordRepository.AddAsync(newGuildUser);
		else
		{
			userVcTimeRecord.TimeSpentMilliseconds += newGuildUser.TimeSpentMilliseconds;
			await vcTimeRecordRepository.Update(userVcTimeRecord);
		}
	}

	public async Task<string> GetTimeByIdAsync(ulong guildId, ulong userId)
	{
		var user = await vcTimeRecordRepository.GetByIdAsync(guildId, userId);

		if (user == null)
			return "Usuario no registrado";

		var time = TimeSpan.FromMilliseconds(user.TimeSpentMilliseconds);
		
		var response = string.Format(Constants.VcCommandResponseFormat,
			time.Days, time.Hours, time.Minutes, time.Seconds);
		return response;
	}

	public async Task<string> GetRankingAsync()
	{
		var ranking = await vcTimeRecordRepository.GetRankingAsync();
		
		var response = Constants.VcRankingCommandHeader;

		foreach (var record in ranking)
		{
			var time = TimeSpan.FromMilliseconds(record.TimeSpentMilliseconds);
			response += string.Format(
				Constants.VcRankingCommandResponseFormat,
				record.Username,
				time.Days,
				time.Hours,
				time.Minutes,
				time.Seconds
			);
		}

		return response;
	}
}