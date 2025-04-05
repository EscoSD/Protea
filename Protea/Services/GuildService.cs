using Protea.Interfaces.Repositories;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class GuildService(IGuildRepository guildRepository) : IGuildService
{
	public async Task UpdateAsync(UserGuildDto dto)
	{
		var existingGuild = await guildRepository
			.GetByIdAsync(dto.GuildId);

		var newGuild = new Guild
		{
			Id = dto.GuildId,
			Name = dto.GuildName!
		};

		if (existingGuild == null)
			await guildRepository.AddAsync(newGuild);
		
		else if (existingGuild.Name != newGuild.Name)
			await guildRepository.UpdateAsync(newGuild);
	}
}