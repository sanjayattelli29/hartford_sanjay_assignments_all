using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UMSController : ControllerBase
    {
        // Private static list of users
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "sanjay", Number = "1234567890", Salary = 50000 },
            new User { Id = 2, Name = "srinidhi", Number = "9876543210", Salary = 60000 },
            new User { Id = 3, Name = "uma", Number = "5556667777", Salary = 55000 }
        };

        // Public method to retrieve all users
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(users);
        }

        // Public method to retrieve user by Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }
        // Public method to add a new user
        [HttpPost]
        public IActionResult PostAction([FromBody] User newUser)
        {
            if (newUser == null)
                return BadRequest("Invalid user data");
            newUser.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1; // Auto-increment Id
            users.Add(newUser);
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAction(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("User not found");
            users.Remove(user);
            return NoContent();
        }
    }
}
