namespace Task_Manager_API.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = ""; 
        public string Email { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    }
}
