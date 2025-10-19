using eCommerce.Core.DTO;
using eCommerce.Core.ServicesContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService _usersService) : ControllerBase
    {

        [HttpGet("{userID}")]
        public async Task<IActionResult> GetUserByUserID(Guid userID)
        {
            if (userID == Guid.Empty)
            {
                return BadRequest("Invalid User ID");
            }

            UserDTO? response = await _usersService.GetUserByUserID(userID);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
        //[HttpGet("{userID}")]
        //public async Task<IActionResult> GetUserByUserID(Guid userID)
        //{
        //    if(userID== Guid.Empty)
        //    {
        //        return BadRequest("Invalid UserID");
        //    }
        //    UserDTO? user = await _usersService.GetUserByUserID(userID);
        //    if (user == null)
        //    {
        //        return NotFound(user);
        //    }
        //    return Ok(user);
        //}
    }
}
