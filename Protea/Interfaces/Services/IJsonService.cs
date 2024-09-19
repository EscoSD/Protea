using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IJsonService
{
	Task SaveUserTimeAsync(TimeSpentVc user);
	Task<string> GetUserTimeAsync(string username);
}