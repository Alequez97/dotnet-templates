using TelegramBotTemplate.Commands;
using TelegramBotTemplate.Interfaces;
using TelegramBotTemplate.Services;

namespace TelegramBotTemplate.Extensions;

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