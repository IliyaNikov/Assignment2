using System;
using System.Threading.Tasks;
using Assignment2WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Assignment2WebAPI.Models;

namespace Assignment2WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            Console.WriteLine("controller method started");
            try
            {
                User user = await userService.ValidateUserAsync(username, password);
                Console.WriteLine("Controller method executed");
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}