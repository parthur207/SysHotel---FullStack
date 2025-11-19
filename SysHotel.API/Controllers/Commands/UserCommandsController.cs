using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysHotel.Application.Models;
using SysHotel.Infrastrucuture.Auth.Jwt;

namespace SysHotel.API.Controllers.Commands
{
    [Route("api/userCommands")]
    [ApiController]
    public class UserCommandsController : Controller
    {

        private readonly IJwtInterface _jwtInterface;
        public UserCommandsController(IJwtInterface jwtInterface)
        {
            _jwtInterface = jwtInterface;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserModel UserModel)
        {
            return Created();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel loginModel)
        {
            return Ok();
        }


    }
}
