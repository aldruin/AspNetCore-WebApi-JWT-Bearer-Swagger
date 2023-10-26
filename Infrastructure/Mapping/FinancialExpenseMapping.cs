using CashFlowAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlowAPI.Infrastructure.Mapping;

public class FinancialExpenseMapping : IEntityTypeConfiguration<FinancialExpense>
{
    public void Configure(EntityTypeBuilder<FinancialExpense> builder)
    {
        builder.ToTable("FinancialExpenses");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Value).IsRequired();
        builder.Property(p => p.Caregory).IsRequired();
        builder.Property(p => p.ExpenseDate).IsRequired();
    }
}