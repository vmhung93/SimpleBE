using Microsoft.Extensions.DependencyInjection;

using SimpleBE.Services;
using SimpleBE.Utils;

namespace SimpleBE.Infrastructure
{
    public static class ServiceDependencies
    {
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
