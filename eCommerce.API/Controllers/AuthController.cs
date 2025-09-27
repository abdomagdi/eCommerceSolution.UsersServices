using eCommerce.Core.DTO;
using eCommerce.Core.ServicesContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUsersService _usersService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterationRequest registerationRequest)
        {
            if (registerationRequest == null)
            {
                return BadRequest("Invalid Registeration Data");
            }

            AuthenticationResponse? authenticationResponse = await _usersService.Registation(registerationRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false)
            {

                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid Login Data");
            }

            AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false)
            {

                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

    }
}
