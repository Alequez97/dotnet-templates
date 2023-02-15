using TelegramBot.Commands;
using TelegramBot.Interfaces;
using TelegramBot.Services;

namespace TelegramBot.Extensions;

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