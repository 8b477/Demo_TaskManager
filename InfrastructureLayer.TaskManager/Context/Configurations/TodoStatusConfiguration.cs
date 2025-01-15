using DomainLayer.TaskManager.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.TaskManager.Context.Configurations
{
    internal class TodoStatusConfiguration : IEntityTypeConfiguration<TodoStatus>
    {
        public void Configure(EntityTypeBuilder<TodoStatus> builder)
        {
            builder.HasKey(ts => ts.Id_TodoStatus);

            builder.Property(ts => ts.TodoStatusName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
