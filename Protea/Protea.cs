using Discord;
using Discord.WebSocket;

namespace Protea;

public class Protea
{
	private static DiscordSocketClient _client;

	public static async Task Run()
	{
		_client = new DiscordSocketClient();

		_client.Log += Log;
		_client.UserVoiceStateUpdated += UserVoiceStateUpdatedAsync;
		
		var token = Environment.GetEnvironmentVariable("TOKEN_PROTEA");

		await _client.LoginAsync(TokenType.Bot, token);
		await _client.StartAsync();

		// Block this task until the program is closed.
		await Task.Delay(-1);
	}
	
	private static async Task UserVoiceStateUpdatedAsync(SocketUser user, SocketVoiceState before, SocketVoiceState after)
	{
		// Verificar si el usuario se unió a un canal de voz
		if (before.VoiceChannel == null && after.VoiceChannel != null)
		{
			// Obtener el canal de texto en el que quieres enviar el mensaje (por su nombre o ID)
			
			// Enviar un mensaje al canal de texto
			if (_client.GetChannel(326707470233894912) is IMessageChannel textChannel)
			{
				await textChannel.SendMessageAsync($"Le vas a decir ñ a tu mamita friki");
			}
		}
	}
	
	private static Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}
}