using System.Text.Json;
using Protea.Data;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class JsonService: IJsonService
{
	public async Task<IList<TimeSpentVc>>GetUsers()
	{
		if (!File.Exists(Constants.HallOfShameFilePath))
			return new List<TimeSpentVc>();

		var rawData = await File.ReadAllTextAsync(Constants.HallOfShameFilePath);
		return JsonSerializer.Deserialize<IList<TimeSpentVc>>(rawData) ?? [];
	}

	public async void SaveUserTime(TimeSpentVc user)
	{
		var users = await GetUsers();
		var userToModify = users.FirstOrDefault(u => u.Username!.Equals(user.Username));
		
		if (userToModify != null)
		{
			users.Remove(userToModify);
			userToModify.TimeSpentMilliseconds += user.TimeSpentMilliseconds;
		}
		else
		{
			userToModify = user;
		}
		
		users.Add(userToModify);
		var json = JsonSerializer.Serialize(users);
		
		await File.WriteAllTextAsync(Constants.HallOfShameFilePath, json);
	}
}