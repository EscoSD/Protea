using Microsoft.Extensions.DependencyInjection;
using Protea.Interfaces.Repositories;
using Protea.Repositories;

namespace Protea.IoC;

public static class RepositoriesInstaller
{
	public static void InstallRepositories(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddSingleton<IUserRepository, UserRepository>();
		serviceCollection.AddSingleton<IGuildRepository, GuildRepository>();
		serviceCollection.AddSingleton<IVcTimeRecordRepository, VcTimeRecordRepository>();
	}	
}