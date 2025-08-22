namespace Task_Manager_API.Models.DTO
{
    public class RegisterDto
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
    public class CreateTaskDto
    {
        public User user { get; set; }
        public string Title { get; set; } = "";
        public int Seconds { get; set; }
    }
}
