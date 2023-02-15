using telegram_bot.Commands;
using telegram_bot.Interfaces;
using telegram_bot.Services;

namespace telegram_bot.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramCommandServices(this IServiceCollection services)
    {
        // Common commands
        services.AddScoped<UnknownCommand>();
        services.AddScoped<ITelegramCommand, StartCommand>();

        // Command services
        services.AddScoped<TelegramCommandResolver>();
        services.AddScoped<TelegramUpdateExecutor>();

        // Common telegram helper services
        services.AddSingleton<EmojiProvider>();

        return services;
    }
}