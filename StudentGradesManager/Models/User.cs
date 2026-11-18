namespace StudentGradesManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Role = string.Empty;
        }

        public User(int userId, string username, string password, string role)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
