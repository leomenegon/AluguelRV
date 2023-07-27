using AluguelRV.Core.Models;
using AluguelRV.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Core.Data.EntityConfig;
public class ExpenseEntityConfig : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expense");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityColumn();

        builder.Property(e => e.RentId).IsRequired();
        builder.Property(e => e.Name).IsUnicode();
        builder.Property(e => e.Type).IsRequired().HasDefaultValue(ExpenseType.HouseBill).HasColumnType("TINYINT");
        builder.Property(e => e.Description).IsUnicode();
        builder.Property(e => e.Amount).HasColumnType("smallmoney").IsRequired().HasDefaultValue(false);
        builder.Property(e => e.General).IsRequired().HasDefaultValue(true);
        builder.Property(e => e.UserId).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.CustomDivision).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.UtcNow);
        builder.Property(e => e.Deleted).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.Timestamp).HasDefaultValueSql("(getutcdate())");

        // Gastos
        builder.HasOne(d => d.Rent).WithMany(p => p.Expenses)
        .HasForeignKey(d => d.RentId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Expense_Rent");

        builder.HasOne(d => d.User).WithMany(p => p.Expenses)
        .HasForeignKey(d => d.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Expense_User");
    }
}