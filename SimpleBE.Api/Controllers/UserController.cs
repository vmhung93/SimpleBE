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
        public async Task<IActionResult> Get()
        {
            var users = await _userService.FindAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.FindById(id);
            return user is not null ? Ok(user) : NotFound();
        }
    }
}
