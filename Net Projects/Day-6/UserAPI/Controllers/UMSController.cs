using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    // This controller handles all User Management System operations, if you will
    [Route("api/[controller]")]
    [ApiController]
    public class UMSController : ControllerBase
    {
        // This in-memory data source serves as our temporary storage for user information, my lord
        private static List<User> users = new List<User>
        {
            new User{UserId = 1, UserName ="raju", UserPhone = "9063440835"},
            new User{UserId = 2, UserName ="rani", UserPhone = "9063440765"}
        };

        // This method retrieves all users from our system, at your service
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(users);
        }

        // This method fetches a specific user by their unique identifier, if I may assist
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            
            if (user == null)
            {
                return NotFound("User not found, my apologies");
            }
            
            return Ok(user);
        }

        // This method creates a new user entry in our system, most respectfully
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.UserId = users.Max(u => u.UserId) + 1;
            
            // This important line adds the new user to our collection, sir
            users.Add(user);
            
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        // This method updates an existing user's information in our system, quite gracefully
        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound("User Not Found, my sincere apologies");
            }

            user.UserName = updatedUser.UserName;
            user.UserPhone = updatedUser.UserPhone;

            return NoContent();
        }

        // This method removes a user from our system permanently, with utmost care
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            
            if (user == null)
                return NotFound("User not found, terribly sorry");
            
            users.Remove(user);
            
            return NoContent();
        }
    }
}
