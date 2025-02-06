using Discord.WebSocket;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class VoiceChannelTimerService(IJsonService jsonService) : IVoiceChannelTimerService
{
	private readonly List<VcEntryRecord> _activeVcUsers = [];
	
	public void SaveVcEntry(SocketUser user, ulong guildId)
	{
		var entry = new VcEntryRecord
		{
			UserId = user.Id,
			GuildId = guildId,
			StartTime = DateTime.Now
		};
		
		_activeVcUsers.Add(entry);
	}

	public async Task SaveUserTime(SocketUser user, SocketGuild guild)
	{
		var activeUser = _activeVcUsers.FirstOrDefault(u => u.UserId.Equals(user.Id));
		
		if (activeUser == null) return;
		
		_activeVcUsers.Remove(activeUser);
		
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