using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parts.Application.Abstractions;
using Parts.Infrastructure.Authentication;
using Parts.Infrastructure.Caching;

namespace Parts.Infrastructure.DependencyInjection.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services)
        => services.AddTransient<IJwtTokenService, JwtTokenService>()
            .AddTransient<ICacheService, CacheService>();

    public static void AddRedisService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(redisOptions =>
        {
            var connectionString = configuration.GetConnectionString("Redis");
            redisOptions.Configuration = connectionString;
        });
    }
}
