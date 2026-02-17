using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.DTOs;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Registeration Success");
        }

        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.Email == dto.Email &&
                    x.Password == dto.Password);

            if (user == null)
                return Unauthorized("Invalid Credentials");

            return Ok("Login Successful");
        }
    }
}
