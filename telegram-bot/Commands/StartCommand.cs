using telegram_bot.Constants;
using telegram_bot.Interfaces;

namespace telegram_bot.Commands;

public class StartCommand : ITelegramCommand
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly ILogger<StartCommand> _logger;
    private readonly IConfiguration _configuration;

    public StartCommand(
        ITelegramBotClient telegramBotClient,
        ILogger<StartCommand> logger,
        IConfiguration configuration)
    {
        _telegramBotClient = telegramBotClient;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task SendResponseAsync(Update update)
    {
        var chatId = update.Message.Chat.Id;

        await _telegramBotClient.SendTextMessageAsync(
            chatId,
            $"Welcome to our telegram bot",
            ParseMode.MarkdownV2
        );
    }

    public bool IsResponsibleForUpdate(Update update)
    {
        return update.Message?.Text?.Contains(CommandConstants.Start) ?? false;
    }
}