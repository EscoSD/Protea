using Microsoft.EntityFrameworkCore;
using Protea.Context;
using Protea.Interfaces.Repositories;
using Protea.Models;

namespace Protea.Repositories;

public class UserRepository(ProteaContext context) : IUserRepository
{
	public async Task AddAsync(User user)
	{
		await context.UserTimeSpentVcs.AddAsync(user);
		await context.SaveChangesAsync();
	}

	public async Task<User?> GetByIdAsync(ulong id)
	{
		return await context.UserTimeSpentVcs.FirstOrDefaultAsync(u => u.Id == id);
	}

	public async Task UpdateAsync(User user)
	{
		context.UserTimeSpentVcs.Update(user);
		await context.SaveChangesAsync();
	}
}