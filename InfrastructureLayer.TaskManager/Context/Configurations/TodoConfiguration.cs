using DomainLayer.TaskManager.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Context.Configurations
{
    internal class TodoConfiguration : IEntityTypeConfiguration<Todos>
    {
        public void Configure(EntityTypeBuilder<Todos> builder)
        {
            builder.HasKey(t => t.Id_Todo);

            builder.Property(t => t.TodoName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.TodoDescription)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(t => t.TodoCreatedAt)
                .IsRequired();

            builder.Property(t => t.TodoIsClosed)
                .IsRequired();

            builder.Property(t => t.TodoPriority)
                .IsRequired();

            builder.HasOne(t => t.User)
                .WithMany(u => u.Todos)
                .HasForeignKey(t => t.FK_User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Status)
                .WithMany(ts => ts.Todos)
                .HasForeignKey(t => t.FK_TodoStatus)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
    }
