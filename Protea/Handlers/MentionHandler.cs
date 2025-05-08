using Discord;
using Discord.WebSocket;
using Protea.Data;
using Protea.Interfaces.Handlers;
using Protea.Interfaces.Services;

namespace Protea.Handlers;

public class MentionHandler(DiscordSocketClient client, IGeminiService geminiService) : IMentionHandler
{
	public bool IsGeminiEnabled { get; set; }
	
	public void InstallHandler()
	{
		client.MessageReceived += HandleMention;
		IsGeminiEnabled = true;
	}

	private async Task HandleMention(SocketMessage messageParam)
	{
		if (!IsGeminiEnabled || messageParam.Author.IsBot || messageParam is not SocketUserMessage message)
			return;

		if (message.MentionedUsers.Any(user => user.Id == client.CurrentUser.Id))
		{
			var response = await geminiService.GetResponse(message.Content);
			await SendResponse(message, response);
		}
	}

	private static async Task SendResponse(SocketUserMessage message, string response)
	{
		var parts = Enumerable
			.Range(0, (response.Length + Constants.MessageMaxLength - 1) / Constants.MessageMaxLength)
			.Select(i => response.Substring(i * Constants.MessageMaxLength,
				Math.Min(Constants.MessageMaxLength, response.Length - i * Constants.MessageMaxLength)))
			.ToList();

		var replyMessage = await message.ReplyAsync(parts[0]);

		for (var i = 1; i < parts.Count; i++)
			replyMessage = await replyMessage.ReplyAsync(parts[i]);
	}
}