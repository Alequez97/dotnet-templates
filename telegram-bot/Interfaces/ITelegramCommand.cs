namespace telegram_bot.Interfaces;

public interface ITelegramCommand
{
    Task SendResponseAsync(Update update);

    bool IsResponsibleForUpdate(Update update);
}