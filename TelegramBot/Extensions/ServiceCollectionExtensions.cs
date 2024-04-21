using TelegramBotTemplate.Services.Common;
using TelegramBotTemplate.Services.Telegram;

using TelegramBotTemplate.Commands;
using TelegramBotTemplate.Interfaces;

namespace TelegramBotTemplate.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramCommandServices(this IServiceCollection services)
    {
        // Common commands
        services.AddScoped<UnknownCommand>();
        services.AddScoped<ITelegramCommand, StartCommand>();

        // Command services
        services.AddScoped<CommandResolver>();
        services.AddScoped<UpdateResponseSender>();

        // Common telegram helper services
        services.AddSingleton<EmojiProvider>();

        return services;
    }
}