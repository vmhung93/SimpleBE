using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SimpleBE.Api.Dtos;
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
        public async Task<IActionResult> SignUp(SignUpDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _authService.SignUp(dto);
            return Ok();
        }

        [HttpPost]
        [Route("sign_in")]
        public IActionResult SignIn(SignInDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var auth = _authService.SignIn(dto);

            if (auth == null)
            {
                return Unauthorized();
            }

            return Ok(auth);
        }
    }
}
