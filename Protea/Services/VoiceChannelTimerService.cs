using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class VoiceChannelTimerService(IJsonService jsonService) : IVoiceChannelTimerService
{
	private readonly List<StartTimeVc> _usersCache = [];
	
	public void SaveStv(string username)
	{
		var stv = new StartTimeVc
		{
			Username = username,
			StartTime = DateTime.Now
		};
			
		_usersCache.Add(stv);
	}

	public async Task SaveUserTime(string username)
	{
		var cacheUser = _usersCache.FirstOrDefault(u => u.Username!.Equals(username));
		
		if (cacheUser == null)
			return;
		
		_usersCache.Remove(cacheUser);
		
		var user = new TimeSpentVc
		{
			Username = username,
			TimeSpentMilliseconds =
				Convert.ToInt64((DateTime.Now - cacheUser.StartTime)
				.TotalMilliseconds)
		};

		await jsonService.SaveUserTimeAsync(user);
	}
}