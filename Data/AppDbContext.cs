using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task_Manager_API.Models;

namespace Task_Manager_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
