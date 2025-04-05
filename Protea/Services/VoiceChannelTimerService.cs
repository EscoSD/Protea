using System.Collections.Immutable;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class VoiceChannelTimerService(IVcTimeRecordService vcTimeRecordService, IUserService userService, IGuildService guildService) : IVoiceChannelTimerService
{
	private ImmutableList<VcEntryRecord> _activeVcUsers = ImmutableList<VcEntryRecord>.Empty;
	
	public void SaveVcEntry(UserGuildDto dto)
	{
		var entry = new VcEntryRecord
		{
			UserId = dto.UserId,
			GuildId = dto.GuildId,
			StartTime = DateTime.Now
		};
		
		ImmutableInterlocked.Update(ref _activeVcUsers, list => list.Add(entry));
	}

	public async Task SaveUserTime(UserGuildDto dto)
	{
		var activeUser = _activeVcUsers.FirstOrDefault(u => u.UserId.Equals(dto.UserId));
		if (activeUser == null) return;
		
		ImmutableInterlocked.Update(ref _activeVcUsers, list => list.Remove(activeUser));
		
		await RegisterGuildUser(dto);
		await vcTimeRecordService.UpdateAsync(activeUser);
	}

	private async Task RegisterGuildUser(UserGuildDto dto)
	{
		await userService.UpdateAsync(dto);
		await guildService.UpdateAsync(dto);
	}
}