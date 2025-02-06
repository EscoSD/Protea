using Discord.WebSocket;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class VoiceChannelTimerService(List<VcEntryRecord> activeVcUsers, IJsonService jsonService) : IVoiceChannelTimerService
{
	public void SaveVcEntry(SocketUser user, ulong guildId)
	{
		var entry = new VcEntryRecord
		{
			UserId = user.Id,
			GuildId = guildId,
			StartTime = DateTime.Now
		};
		
		activeVcUsers.Add(entry);
	}

	public async Task SaveUserTime(SocketUser user, SocketGuild guild)
	{
		var activeUser = activeVcUsers.FirstOrDefault(u => u.UserId.Equals(user.Id));
		
		if (activeUser == null) return;
		
		activeVcUsers.Remove(activeUser);
		
		var userTimeRecord = new TimeSpentVc
		{
			UserId = user.Id,
			Username = user.Username,
			GuildId = guild.Id,
			GuildName = guild.Name,
			TimeSpentMilliseconds =
				Convert.ToInt64((DateTime.Now - activeUser.StartTime)
				.TotalMilliseconds)
		};

		await jsonService.SaveUserTimeAsync(userTimeRecord);
	}
}