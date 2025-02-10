using Discord.WebSocket;
using Protea.Interfaces.Repositories;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class GuildService(IGuildRepository guildRepository) : IGuildService
{
	public async Task UpdateAsync(SocketGuild guild)
	{
		var existingGuild = await guildRepository
			.GetByIdAsync(guild.Id);

		var newGuild = new Guild
		{
			Id = guild.Id,
			Name = guild.Name,
		};

		if (existingGuild == null)
			await guildRepository.AddAsync(newGuild);
		
		else if (existingGuild.Name != newGuild.Name)
			await guildRepository.UpdateAsync(newGuild);
	}
}