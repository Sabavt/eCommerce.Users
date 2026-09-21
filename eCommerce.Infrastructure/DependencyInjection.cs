using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services into dependecy injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns>Returns dependecy injection container with added infrastructure services</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}
