using Microsoft.Extensions.DependencyInjection;

using SimpleBE.Services;

namespace SimpleBE.Infrastructure
{
    public static class ServiceDependencies
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // User
            services.AddTransient<IUserService, UserService>();
        }
    }
}