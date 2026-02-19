using Microsoft.AspNetCore.Mvc;
using UserApi.Data;
using UserApi.DTOs;
using UserApi.Models;
using System;
using System.Linq;

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

        // POST: api/users/register
        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == userDto.Email);

            if (existingUser != null)
                return BadRequest("User already exists");

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                Active = true,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully");
        }

        // POST: api/users/login
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validUser = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email
                                  && u.Password == dto.Password);

            if (validUser == null)
                return Unauthorized("Invalid email or password");

            return Ok("Login successful");
        }

    }
}
