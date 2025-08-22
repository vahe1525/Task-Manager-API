using Microsoft.AspNetCore.Mvc;
using Task_Manager_API.Services;
using Task_Manager_API.Models;
using Task_Manager_API.Models.DTO;
using System.Security.Cryptography;
using System.Text;
using Task_Manager_API.Data;
using Microsoft.EntityFrameworkCore;


namespace Task_Manager_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
       
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var success = await _userService.RegisterAsync(dto.Username.ToLower(), dto.Email, dto.Password);
            if (!success)
                return BadRequest("Username or email already exists");

            return Ok("User registered successfully");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }

}
