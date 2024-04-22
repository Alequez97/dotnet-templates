namespace TelegramBotTemplate.Services.Telegram;

public class UpdateResponseSender
{
    private readonly CommandResolver _commandResolver;

    public UpdateResponseSender(CommandResolver commandResolver)
    {
        _commandResolver = commandResolver;
    }

    public async Task SendResponseAsync(Update update, CancellationToken cancellationToken)
    {
        var command = await _commandResolver.ResolveAsync(update, cancellationToken);

        await command.SendResponseAsync(update, cancellationToken);
    }
}