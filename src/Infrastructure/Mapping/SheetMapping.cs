using CashFlowAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlowAPI.Infrastructure.Mapping;

public class SheetMapping : IEntityTypeConfiguration<Sheet>
{
    public void Configure(EntityTypeBuilder<Sheet> builder)
    {
        builder.ToTable("Sheets");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
        builder.HasMany(p => p.FinancialEntries).WithOne(p => p.Sheet);
        builder.HasMany(p => p.FinancialExpenses).WithOne(p => p.Sheet);
    }
}