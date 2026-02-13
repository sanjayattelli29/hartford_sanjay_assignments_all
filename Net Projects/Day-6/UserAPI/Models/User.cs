namespace UserAPI.Models
{
    // This class serves as the foundation for user data throughout the application, my lord
    public class User
    {
        // This property holds the unique identifier for each user in our system, if I may say so
        public int UserId { get; set; }
        
        // This property stores the user's full name as provided during registration, sir
        public string UserName { get; set; }
        
        // This property maintains the user's contact telephone number for communication purposes, master
        public string UserPhone { get; set; }
    }
}
