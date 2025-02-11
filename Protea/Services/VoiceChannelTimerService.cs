using System.Collections.Immutable;
using Discord.WebSocket;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class VoiceChannelTimerService(IVcTimeRecordService vcTimeRecordService, IUserService userService, IGuildService guildService) : IVoiceChannelTimerService
{
	private ImmutableList<VcEntryRecord> _activeVcUsers = ImmutableList<VcEntryRecord>.Empty;
	
	public void SaveVcEntry(SocketUser user, ulong guildId)
	{
		var entry = new VcEntryRecord
		{
			UserId = user.Id,
			GuildId = guildId,
			StartTime = DateTime.Now
		};
		
		ImmutableInterlocked.Update(ref _activeVcUsers, list => list.Add(entry));
	}

	public async Task SaveUserTime(SocketUser user, SocketGuild guild)
	{
		var activeUser = _activeVcUsers.FirstOrDefault(u => u.UserId.Equals(user.Id));
		if (activeUser == null) return;
		
		ImmutableInterlocked.Update(ref _activeVcUsers, list => list.Remove(activeUser));
		
		await RegisterGuildUser(user, guild);
		await vcTimeRecordService.UpdateAsync(activeUser);
	}

	private async Task RegisterGuildUser(SocketUser user, SocketGuild guild)
	{
		await userService.UpdateAsync(user);
		await guildService.UpdateAsync(guild);
	}
}