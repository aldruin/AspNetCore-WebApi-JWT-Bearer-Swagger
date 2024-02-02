using CashFlowAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlowAPI.Infrastructure.Mapping;
public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
        builder.Property(p=>p.Salt).IsRequired();
        builder.Property(p=>p.Role).IsRequired();

        builder.HasMany(x => x.Sheets).WithOne().HasForeignKey(x => x.UserId);

        builder.OwnsOne(x => x.Email, p =>
        {
            p.Property(f => f.Value).HasColumnName("Email").IsRequired().HasMaxLength(1024);
        });
        builder.OwnsOne(x => x.Password, p =>
        {
            p.Property(f => f.Value).HasColumnName("Password").IsRequired();
        });
    }
}