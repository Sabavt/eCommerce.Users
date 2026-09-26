using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services into dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns>Returns dependency injection container with added infrastructure services</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();

        return services;
    }
}
