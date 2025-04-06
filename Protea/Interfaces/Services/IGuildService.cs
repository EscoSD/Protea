using Protea.Models;

namespace Protea.Interfaces.Services;

public interface IGuildService
{
	Task UpdateAsync(UserGuildDto dto);
}