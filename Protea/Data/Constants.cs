namespace Protea.Data;

public static class Constants
{
	public const ulong AdminId = 323418069093449729;

	public const string CatApiUrl = "https://api.thecatapi.com/v1/images/search";
	public const string CatApiErrorUrl = "https://i.ytimg.com/vi/hxN_yHI6czw/sddefault.jpg";

	public const string DogApiUrl = "https://dog.ceo/api/breeds/image/random";
	public const string DogApiErrorUrl =
		"https://sm.ign.com/ign_es/image/k/kabosu-the/" +
		"kabosu-the-dog-behind-the-doge-meme-has-died_k7ec.jpg";

	public const string PigImgUrl =
		"https://media.discordapp.net/attachments/326707470233894912/1333598763918299249/" + 
		"image.png?ex=67ac97e2&is=67ab4662&hm=f8207b3979b6f091c20100bb7f354e09b6dcb57e390d" +
		"0e42fb0f93dffc8cd648&=&format=webp&quality=lossless&width=1193&height=671";
	
	public const char CommandsPrefix = '¿';

	// COMANDOS

	public const string HelpCommandText = "help";
	public const string VcTimeCommandText = "vcTime";
	public const string VcRankingCommandText = "vcRanking";
	public const string SleepCommandText = "sleep";
	public const string CatMeCommandText = "catMe";
	public const string DogMeCommandText = "dogMe";
	public const string PigCommandText = "carteles";

	// DESCRIPCIONES DE COMANDOS
	
	public const string HelpCommandDescription = "Muestra los comandos de Protea";
	
	public const string VcTimeCommandDescription =
		"Muestra el tiempo que has pasado en canales de voz dentro de este servidor." +
		"\nContando desde el 15-09-2024 a las 14:53:52";

	public const string VcRankingCommandDescription =
		"Muestra el ranking de los 5 usuarios que mas tiempo han pasado en los canales de voz." +
		"\nContando desde el 15-09-2024 a las 14:53:52";
	
	public const string SleepCommandDescription = "Se desactiva el Bot y se termina el programa";
	public const string CatMeCommandDescription = "Invoca un gato";
	public const string DogMeCommandDescription = "Invoca un perro";
	public const string PigCommandDescription = "Invoca un cerdo";


	// FORMATOS DE RESPUESTAS
	
	public const string VcTimeCommandTitle = "Vida perdida en VCs";
	public const string VcTimeCommandDescFormat = "**{0}d {1}h {2}m {3}s**";

	public const string VcRankingCommandTitle = "TOP 5 PERDEDORES";
	public const string VcRankingTitleUrl = "https://www.youtube.com/watch?v=-i_TnZw9dYU";
	public const string VcRankingCommandDescFormat = "**{0}**: {1}d {2}h {3}m {4}s\n\n";
}