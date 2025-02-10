using Protea.Models;

namespace Protea.Interfaces.Repositories;

public interface IUserRepository
{
	Task AddAsync(User user);
	Task<User?> GetByIdAsync(ulong id);
	Task UpdateAsync(User user);
}