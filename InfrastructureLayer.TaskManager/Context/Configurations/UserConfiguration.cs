using DomainLayer.TaskManager.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Context.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.Id_User);

            builder.Property(u => u.UserName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.FK_Role)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
