using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get;set;}
        public DbSet<TaskGroup> TaskGroups{get; set;}
        public DbSet<Habit> Habits {get;set;}
        public DbSet<DailyLog> DailyLogs {get;set;}
    }
}