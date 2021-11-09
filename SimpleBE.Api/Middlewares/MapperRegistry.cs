using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleBE.Api.Middlewares
{
    public static class MapperRegistry
    {
        public static void RegisterMapper(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
