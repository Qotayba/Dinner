using BuberDinner.Api.Filters;
using BuberDinner.Api.Mapping;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentiation(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<ErorrHandlingFilterAttribute>());
            services.AddMappings();
            return services;
        }
    }
}
