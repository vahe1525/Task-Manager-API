using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_API.Models
{
    public class TaskItem
    {
        public int Id {  get; set; } = default(int);
        public string Title { get; set; } = "-";
        public StatusItem Status { get; set; } = StatusItem.NotStarted;

        public string Description { get; set; } = "-";

        public DateTime Created { get; set; }
        public DateTime DeadLine { get; set; }

        // Foreign keys 
        public Guid UserId { get; set; }


        public TaskItem(string title,int seconds, Guid userId) 
        {
            DeadLine = DateTime.UtcNow.AddSeconds(seconds);
            Created = DateTime.UtcNow;
            Title = title;
            UserId = userId;
        }
        public override string ToString()
        {
            return $"{Id} -- {Title} -- {Description} -- {Status}";
        }

        public TaskItem() { }
    }

}
