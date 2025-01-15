using DomainLayer.TaskManager.Entities;

using InfrastructureLayer.TaskManager.Context.Configurations;

using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Context
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) {}


        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Todos> Todos { get; set; }
        public DbSet<TodoStatus> TodoStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TodoStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }
    }
}
