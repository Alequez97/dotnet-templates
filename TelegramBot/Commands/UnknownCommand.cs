using TelegramBotTemplate.Interfaces;

namespace TelegramBotTemplate.Commands;

public class UnknownCommand : ITelegramCommand
{
    private readonly ITelegramBotClient _telegramBotClient;

    public UnknownCommand(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task SendResponseAsync(Update update, CancellationToken cancellationToken)
    {
        var chatId = update?.Message?.Chat?.Id;

        if (chatId != null)
        {
            await _telegramBotClient.SendTextMessageAsync(
                chatId,
                $"Unknown command was sent",
                ParseMode.MarkdownV2,
                cancellationToken: cancellationToken
            );
        }
    }

    public Task<bool> IsResponsibleForUpdateAsync(Update update, CancellationToken _)
    {
        return Task.FromResult(false);
    }
}