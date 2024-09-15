using System.Text.Json;
using Protea.Interfaces.Services;
using Protea.Models;
using Protea.Models.Configuration;

namespace Protea.Services;

public class JsonService(ConfigurationApp config): IJsonService
{
	public async Task<IList<TimeSpentVc>>GetUsers()
	{
		if (!File.Exists(config.VcTimerFilePath))
			return new List<TimeSpentVc>();

		var rawData = await File.ReadAllTextAsync(config.VcTimerFilePath);
		return JsonSerializer.Deserialize<IList<TimeSpentVc>>(rawData) ?? [];
	}

	public async Task SaveUserTime(TimeSpentVc user)
	{
		var users = await GetUsers();
		var userToModify = users.FirstOrDefault(u => u.Username!.Equals(user.Username)) ?? user;
		
		if (userToModify != user)
		{
			users.Remove(userToModify);
			userToModify.TimeSpentMilliseconds += user.TimeSpentMilliseconds;
		}
		
		users.Add(userToModify);
		var json = JsonSerializer.Serialize(users);
		
		await File.WriteAllTextAsync(config.VcTimerFilePath, json);
	}
}