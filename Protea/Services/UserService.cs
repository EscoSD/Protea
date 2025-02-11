using Discord.WebSocket;
using Protea.Interfaces.Repositories;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
	public async Task UpdateAsync(SocketUser user)
	{
		var existingUser = await userRepository
			.GetByIdAsync(user.Id);

		var newUser = new User
		{
			Id = user.Id,
			Username = user.Username,
		};

		if (existingUser == null)
			await userRepository.AddAsync(newUser);
		
		else if (existingUser.Username != newUser.Username)
			await userRepository.UpdateAsync(newUser);
	}
}