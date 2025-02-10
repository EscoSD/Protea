using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Protea.Context;
using Protea.Models.Configuration;

namespace Protea.IoC;

public static class ContextInstaller
{
	public static void InstallContext(this IServiceCollection serviceCollection, ConfigurationApp config) {
		serviceCollection.AddDbContext<ProteaContext>(options => 
			options.UseSqlite(config.DbConnectionString));
	}
}