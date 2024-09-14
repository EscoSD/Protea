using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IJsonService
{
	void SaveUserTime(TimeSpentVc user);
}