using Microsoft.Extensions.DependencyInjection;

using SimpleBE.Infrastructure.Repositories;

namespace SimpleBE.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Unit of works
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
