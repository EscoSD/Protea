namespace Protea.Data;

public static class Constants
{
	public const char CommandsPrefix = '¿';

	public const string VcTimeCommandText = "vcTime";
	public const string VcRankingCommandText = "vcRanking";
	public const string SleepCommandText = "sleep";

	public const string VcTimeCommandDesc =
		"Revela el tiempo que has pasado en canales de voz dentro de este servidor." +
		"\nContando desde el 15-09-2024 a las 14:53:52";

	public const string VcRankingCommandDesc =
		"Muestra el ranking de los 5 usuarios que mas tiempo han pasado en los canales de voz." +
		"\nContando desde el 15-09-2024 a las 14:53:52";
	
	public const string SleepCommandDesc = "Se desactiva el Bot y se termina el programa";

	public const string VcCommandResponseFormat = "Vida perdida en VCs:\n {0}d {1}h {2}m {3}s";

	public const string VcRankingCommandHeader = "===========\n   RANKING\n===========\n\n";
	public const string VcRankingCommandResponseFormat = "{0}: {1}d {2}h {3}m {4}s\n\n";
}