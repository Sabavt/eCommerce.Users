using eCommerce.Core.Mappers;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services into dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns>Returns dependency injection container with added core services</returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IUsersService, UsersService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        services.AddAutoMapper(cfg => {
            cfg.AddProfile<ApplicationUserMappingProfile>();
            cfg.AddProfile<RegisterRequestMappingProfile>();
            cfg.AddProfile<UserDTOMappingProfile>();
        });

        return services;
    }
}
