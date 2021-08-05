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
        public async Task<IActionResult> Post(AuthDTO dto)
        {
            var auth = await _authService.Authenticate(dto);

            if (auth == null)
            {
                return Unauthorized();
            }

            return Ok(auth);
        }
    }
}
