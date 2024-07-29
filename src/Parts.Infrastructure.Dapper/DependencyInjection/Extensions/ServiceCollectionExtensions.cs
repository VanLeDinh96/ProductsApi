using Microsoft.Extensions.DependencyInjection;
using Parts.Domain.Abstractions.Dappers;
using Parts.Domain.Abstractions.Dappers.Repositories.Product;
using Parts.Infrastructure.Dapper.Repositories;

namespace Parts.Infrastructure.Dapper.DependencyInjection.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureDapper(this IServiceCollection services)
        => services.AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IUnitOfWork, UnitOfWork>();
}
