using TelegramBotTemplate.Constants;
using TelegramBotTemplate.Interfaces;

namespace TelegramBotTemplate.Commands;

public class StartCommand : ITelegramCommand
{
    private readonly ITelegramBotClient _telegramBotClient;

    public StartCommand(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task SendResponseAsync(Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;

        await _telegramBotClient.SendTextMessageAsync(
            chatId,
            $"Welcome to our telegram bot",
            ParseMode.MarkdownV2,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsResponsibleForUpdateAsync(Update update, CancellationToken _)
    {
        return Task.FromResult(update.Message?.Text?.Contains(CommandConstants.Start) ?? false);
    }
}