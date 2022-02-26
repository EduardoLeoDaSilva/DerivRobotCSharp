using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace DerivSmartRobot.Redis;

public static class RedisExtension
{
    public static IServiceCollection AddRedis(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connStr = configuration.GetConnectionString("RedisConnection");

        var connOptions = ConfigurationOptions.Parse(connStr);
        connOptions.SyncTimeout = 10000; // default = 5000

        var connection = ConnectionMultiplexer.Connect(connOptions);
            
        services.AddSingleton(connection);
        services.AddSingleton(connection.GetDatabase());
        services.AddSingleton(connection.GetServer(connection.GetEndPoints()[0]));
        services.AddSingleton<ICacheService, RedisService>();
            
        return services;
    }
}