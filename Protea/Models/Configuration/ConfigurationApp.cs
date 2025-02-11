namespace Protea.Models.Configuration;

public class ConfigurationApp
{
	public string? DbConnectionString { get; set; }
	public string? DiscordLogFilePath { get; set; }
	public string? AppLogFilePath { get; set; }
}