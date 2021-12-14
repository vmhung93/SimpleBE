using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

using SimpleBE.Application.Helpers;
using SimpleBE.Application.Services;
using SimpleBE.Application.Utils;

namespace SimpleBE.Application.Middlewares
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
                context.Items["User"] = await userService.FindById(userId.Value);
            }

            await _next(context);
        }
    }
}