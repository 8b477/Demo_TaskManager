using DomainLayer.TaskManager.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.TaskManager.Context.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasKey(r => r.Id_Role);

            builder.Property(r => r.RoleName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(r => r.RoleName)
                .IsUnique();
        }
    }
}
