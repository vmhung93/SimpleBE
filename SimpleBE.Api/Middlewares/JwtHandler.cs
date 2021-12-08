using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

using SimpleBE.Api.Helpers;
using SimpleBE.Api.Services;
using SimpleBE.Api.Utils;

namespace SimpleBE.Api.Middlewares
{
    public class JwtHandler
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtHandler(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);

            if (userId != null)
            {
                context.Items["User"] = userService.FindById(userId.Value);
            }

            await _next(context);
        }
    }
}