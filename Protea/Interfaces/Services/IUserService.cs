using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IUserService
{
	Task UpdateAsync(UserGuildDto dto);
}