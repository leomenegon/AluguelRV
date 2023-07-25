using AluguelRV.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Core.Data.EntityConfig;
public class ExpensePersonEntityConfig : IEntityTypeConfiguration<ExpensePerson>
{
    public void Configure(EntityTypeBuilder<ExpensePerson> builder)
    {
        builder.ToTable("ExpensePerson");

        builder.HasKey(x => new {x.PersonId, x.ExpenseId});

        builder.Property(e => e.CustomAmount).HasColumnType("smallmoney");

        builder.HasOne(d => d.Expense).WithMany()
            .HasForeignKey(d => d.ExpenseId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ExpensePerson_Expense");

        builder.HasOne(d => d.Person).WithMany()
            .HasForeignKey(d => d.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ExpensePerson_Person");
    }
}