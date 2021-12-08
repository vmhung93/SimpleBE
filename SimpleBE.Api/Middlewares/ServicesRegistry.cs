using Microsoft.Extensions.DependencyInjection;

using SimpleBE.Api.Infrastructure;
using SimpleBE.Api.Services;
using SimpleBE.Api.Utils;

namespace SimpleBE.Api.Middlewares
{
    public static class ServicesRegistry
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Unit of works
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            // Services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            // Utils
            services.AddTransient<IJwtUtils, JwtUtils>();
        }
    }
}
