namespace TelegramBotTemplate.Interfaces;

public interface ITelegramCommand
{
    Task SendResponseAsync(Update update, CancellationToken cancellationToken);

    Task<bool> IsResponsibleForUpdateAsync(Update update, CancellationToken cancellationToken);
}