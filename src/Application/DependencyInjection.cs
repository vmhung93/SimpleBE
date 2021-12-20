using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using SimpleBE.Application.Behaviours;
using SimpleBE.Application.Utils;
using SimpleBE.Application.Users.Services;
using SimpleBE.Application.Auth.Services;

namespace SimpleBE.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Mapper
            services.RegisterMapper();

            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Services 
            services.RegisterServices();

            return services;
        }

        public static void RegisterMapper(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            // Services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            // Utils
            services.AddTransient<IJwtUtils, JwtUtils>();
        }
    }
}
