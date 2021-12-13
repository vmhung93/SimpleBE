using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SimpleBE.Api.Commands;
using SimpleBE.Api.Services;

namespace SimpleBE.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        [Route("sign_up")]
        public async Task<IActionResult> SignUp(SignUpCommand command)
        {
            await _authService.SignUp(command);
            return Ok();
        }

        [HttpPost]
        [Route("sign_in")]
        public async Task<IActionResult> SignIn(SignInCommand command)
        {
            var auth = await _authService.SignIn(command);
            return auth is not null ? Ok(auth) : Unauthorized();
        }
    }
}
