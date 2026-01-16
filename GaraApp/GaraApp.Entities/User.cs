using System;

namespace GaraApp.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "User"; // Admin, User
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
