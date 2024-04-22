using TelegramBotTemplate.Commands;
using TelegramBotTemplate.Exceptions;
using TelegramBotTemplate.Interfaces;

namespace TelegramBotTemplate.Services.Telegram;

public class CommandResolver
{
    private readonly IEnumerable<ITelegramCommand> _commands;
    private readonly UnknownCommand _unknownCommand;

    public CommandResolver(IEnumerable<ITelegramCommand> commands, UnknownCommand unknownCommand)
    {
        _commands = commands;
        _unknownCommand = unknownCommand;
    }

    public async Task<ITelegramCommand> ResolveAsync(Update update, CancellationToken cancellationToken)
    {
        var responsibleForUpdateCommands = new List<ITelegramCommand>();

        foreach (var command in _commands)
        {
            if (await command.IsResponsibleForUpdateAsync(update, cancellationToken))
            {
                responsibleForUpdateCommands.Add(command);
            }
        }

        if (responsibleForUpdateCommands.Count > 1)
        {
            var responsibleForUpdateTypesAsString = string.Join(", ", responsibleForUpdateCommands.Select(command => command.GetType().Name));
            throw new MoreThanOneCommandIsResponsibleForUpdateException($"More than one command found as responsible for incoming update. List of commands that match same update: {responsibleForUpdateTypesAsString}");
        }

        if (responsibleForUpdateCommands.Count == 0)
        {
            return _unknownCommand;
        }

        return responsibleForUpdateCommands.First();
    }
}