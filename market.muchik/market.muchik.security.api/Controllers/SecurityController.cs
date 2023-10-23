using Microsoft.AspNetCore.Mvc;
using market.muchik.security.application.dto;
using market.muchik.security.application.interfaces;

namespace market.muchik.security.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_securityService.GetAllUsers());
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] CreateUserDto userDto)
        {
            _securityService.SignUp(userDto);
            return Ok();
        }

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody] SignInRequestDto signInRequestDto)
        {
            return Ok(_securityService.SignIn(signInRequestDto));
        }
    }
}
