using TelegramBotTemplate.Commands;
using TelegramBotTemplate.Interfaces;

namespace TelegramBotTemplate.Services;

public class TelegramCommandResolver
{
    private readonly IEnumerable<ITelegramCommand> _commands;
    private readonly UnknownCommand _unknownCommand;

    public TelegramCommandResolver(IEnumerable<ITelegramCommand> commands, UnknownCommand unknownCommand)
    {
        _commands = commands;
        _unknownCommand = unknownCommand;
    }

    public ITelegramCommand Resolve(Update update)
    {
        var command = _commands.FirstOrDefault(command => command.IsResponsibleForUpdate(update));

        if (command == null)
        {
            return _unknownCommand;
        }

        return command;
    }
}