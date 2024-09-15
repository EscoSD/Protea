using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IJsonService
{
	Task<IList<TimeSpentVc>>GetUsers();
	Task SaveUserTime(TimeSpentVc user);
}