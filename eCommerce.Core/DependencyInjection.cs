using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services into dependecy injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns>Returns dependecy injection container with added core services</returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}
