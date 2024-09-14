namespace Protea.Models;

// Modelo para el archivo de registro de tiempo pasado en un canal de voz.
public class TimeSpentVc
{
	public string? Username { get; init; }
	public long TimeSpentMilliseconds { get; set; }
}
