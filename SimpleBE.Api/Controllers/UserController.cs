using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SimpleBE.Api.Authorization;
using SimpleBE.Api.Enums;
using SimpleBE.Api.Services;

namespace SimpleBE.Api.Controllers
{
    [Authorize(Role.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.FindAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.FindById(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("seed")]
        [AllowAnonymous]
        public async Task<IActionResult> Seed()
        {
            await _userService.Seed();
            return Ok();
        }
    }
}
