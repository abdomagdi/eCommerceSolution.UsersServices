using eCommerce.Core.RepositoriesContracts;
using eCommerce.Core.ServicesContracts;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core.Services;
using eCommerce.Core.Mappers;
using FluentValidation;
using eCommerce.Core.DTO;
using eCommerce.Core.Validators;
namespace eCommerce.Core
{
    public static class DependancyInjection
    {

        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
            //services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
            return services;

        }
    }
}
