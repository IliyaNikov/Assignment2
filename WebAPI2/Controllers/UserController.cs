using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Data;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User user = await userService.ValidateUserAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}