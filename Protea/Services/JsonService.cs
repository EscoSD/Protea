using System.Text.Json;
using Protea.Data;
using Protea.Interfaces.Services;
using Protea.Models;
using Protea.Models.Configuration;

namespace Protea.Services;

public class JsonService(ConfigurationApp config): IJsonService
{
	public async Task SaveUserTimeAsync(TimeSpentVc user)
	{
		var users = await GetUsersAsync();
		var userToModify = users.FirstOrDefault(u => u.Username!.Equals(user.Username)) ?? user;
		
		if (userToModify != user)
		{
			users.Remove(userToModify);
			userToModify.TimeSpentMilliseconds += user.TimeSpentMilliseconds;
		}
		
		users.Add(userToModify);
		var json = JsonSerializer.Serialize(users);
		
		await File.WriteAllTextAsync(config.VcTimerFilePath ?? "", json);
	}

	public async Task<string> GetUserTimeAsync(string username)
	{
		var users = await GetUsersAsync();
		var user = users.FirstOrDefault(u => u.Username!.Equals(username));

		if (user == null)
			return "Usuario no registrado";
		
		var time = TimeSpan.FromMilliseconds(user.TimeSpentMilliseconds);
		
		return string.Format(Constants.VcCommandResponseFormat, time.Days, time.Hours, time.Minutes, time.Seconds);
	}

	public async Task<string> GetVcRankingAsync()
	{
		var users = await GetUsersAsync();
		var list = users.OrderByDescending(u => u.TimeSpentMilliseconds).Take(5);

		var response = "Ranking:\n\n";

		foreach (var user in list)
		{
			var time = TimeSpan.FromMilliseconds(user.TimeSpentMilliseconds);
			var formated = string.Format(Constants.VcRankingCommandResponseFormat, time.Days, time.Hours, time.Minutes, time.Seconds);

			response += $"{user.Username}.- {formated}\n";
		}

		return response;
	}

	private async Task<IList<TimeSpentVc>>GetUsersAsync()
	{
		if (!File.Exists(config.VcTimerFilePath))
			return new List<TimeSpentVc>();

		var rawData = await File.ReadAllTextAsync(config.VcTimerFilePath);
		return JsonSerializer.Deserialize<IList<TimeSpentVc>>(rawData) ?? [];
	}
}