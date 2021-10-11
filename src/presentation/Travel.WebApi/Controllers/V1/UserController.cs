using Microsoft.AspNetCore.Mvc;
using Travel.Application.Commons.Interfaces;
using Travel.Application.Dtos.Users;

namespace Travel.WebApi.Controllers.V1
{
    /// <summary>
    /// No need to derive from ApiController.
    /// The controller is using a repository pattern and
    /// a hard coded user to make it simple.
    /// You decide whether to use Auth0, IdentityServer4, or the simple ASPNET.Identity.Core
    /// </summary>
    
    
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;
        
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}