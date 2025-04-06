using Protea.Interfaces.Repositories;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
	public async Task UpdateAsync(UserGuildDto dto)
	{
		var existingUser = await userRepository
			.GetByIdAsync(dto.UserId);

		var newUser = new User
		{
			Id = dto.UserId,
			Username = dto.Username!
		};

		if (existingUser == null)
			await userRepository.AddAsync(newUser);
		
		else if (existingUser.Username != newUser.Username)
			await userRepository.UpdateAsync(newUser);
	}
}