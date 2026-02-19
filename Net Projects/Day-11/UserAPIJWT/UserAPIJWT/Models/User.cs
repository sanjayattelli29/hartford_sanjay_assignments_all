using System;

namespace UserAPIJWT.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
