using DomainLayer.TaskManager.Entities;

using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Context
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) {}


        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Todos> Todos { get; set; }
        public DbSet<TodoStatus> TodoStatuses { get; set; }
    }
}
