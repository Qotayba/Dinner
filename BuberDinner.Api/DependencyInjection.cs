using BuberDinner.Api.Filters;
using BuberDinner.Api.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection.Metadata.Ecma335;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentiation(this IServiceCollection services)
        {
            services.AddSweager();
            services.AddControllers(options => options.Filters.Add<ErorrHandlingFilterAttribute>());
            services.AddMappings();
            return services;
        }






        private static IServiceCollection AddSweager(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Name = "Autherization",
                        Description = "Enter the barear Autherization :`Bearer Genreated-JWT-Token`",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"

                    });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
         {
        new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
        {
            Type= ReferenceType.SecurityScheme,
            Id=JwtBearerDefaults.AuthenticationScheme
        } },new string[] {}
        }
    });
            });

            return services;
        }

    }

}
