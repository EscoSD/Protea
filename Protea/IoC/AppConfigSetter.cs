using Microsoft.Extensions.Configuration;
using Protea.Models.Configuration;

namespace Protea.IoC;

public static class AppConfigSetter
{
	public static ConfigurationApp SetConfig(this ConfigurationApp model)
	{
		var config = new ConfigurationManager();
		config.AddJsonFile("appsettings.json");

		config.GetSection("ConfigurationApp").Bind(model);

		return model;
	}
}