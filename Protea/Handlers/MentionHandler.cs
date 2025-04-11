using Discord;
using Discord.WebSocket;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;

namespace Protea.Handlers;

public class MentionHandler(DiscordSocketClient client, IGeminiService geminiService) : IMentionHandler
{
	public void InstallHandler()
	{
		client.MessageReceived += HandleMention;
	}

	private async Task HandleMention(SocketMessage messageParam)
	{
		if (messageParam.Author.IsBot || messageParam is not SocketUserMessage message)
			return;
		
		if (message.MentionedUsers.Any(user => user.Id == client.CurrentUser.Id))
		{
			var response = await geminiService.GetResponse(message.Content);
			await message.ReplyAsync(response);
		}
	}
}