using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using SimpleBE.Helpers;
using SimpleBE.Infrastructure;
using SimpleBE.Middlewares;
using SimpleBE.Models;

namespace SimpleBE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Cache results of a preflight request 
        readonly int preflightMaxAge = 86400;

        readonly string allowOrigins = "_allowOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable Cross-Origin request, see https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.0
            services.AddCors(options =>
            {
                options.AddPolicy(allowOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .WithOrigins("http://localhost:4200")
                           .SetPreflightMaxAge(TimeSpan.FromSeconds(preflightMaxAge));
                });
            });

            services.AddControllers();

            // Register the database context
            services.AddDbContext<DatabaseContext>(opt =>
                                               opt.UseInMemoryDatabase("SimpleBE"));

            // Config swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleBE", Version = "v1" });
            });

            // Configure strongly typed settings objects
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Register services
            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleBE v1"));
            }

            // Enable Cross-Origin Request, see https://docs.microsoft.com/en-us/aspnet/core/security/cors
            app.UseCors(allowOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Configure handing errors globally
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // Custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
