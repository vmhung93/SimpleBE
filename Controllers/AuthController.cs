using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SimpleBE.Dtos;
using SimpleBE.Services;

namespace SimpleBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<UserController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        [Route("sign_up")]
        public async Task<IActionResult> SignUp(SignUpDTO dto)
        {
            await _authService.SignUp(dto);
            return Ok();
        }

        [HttpPost]
        [Route("sign_in")]
        public IActionResult SignIn(SignInDTO dto)
        {
            var auth = _authService.SignIn(dto);

            if (auth == null)
            {
                return Unauthorized();
            }

            return Ok(auth);
        }
    }
}
