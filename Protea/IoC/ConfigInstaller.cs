using Microsoft.Extensions.DependencyInjection;
using Protea.Models.Configuration;

namespace Protea.IoC;

public static class ConfigInstaller
{
	public static void InstallConfig(this IServiceCollection serviceCollection, ConfigurationApp config)
	{
		serviceCollection.AddSingleton<ConfigurationApp>(config);
	}
}