using AluguelRV.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Core.Data.EntityConfig;
public class RentPaymentEntityConfig : IEntityTypeConfiguration<RentPayment>
{
    public void Configure(EntityTypeBuilder<RentPayment> builder)
    {
        builder.ToTable("RentPayment");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityColumn();

        builder.Property(e => e.RentId).IsRequired();
        builder.Property(e => e.PersonId).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.ReceiptPath);
        builder.Property(e => e.Amount).HasColumnType("smallmoney").IsRequired();
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
        builder.Property(e => e.Deleted).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.Timestamp).HasDefaultValueSql("(getutcdate())");

        builder.HasOne(e => e.Rent)
            .WithMany(r => r.Payments)
            .HasForeignKey(e => e.RentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RentPayment_Rent");

        builder.HasOne(e => e.Person)
            .WithMany(r => r.RentPayments)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RentPayment_Person");

        builder.HasOne(e => e.User)
            .WithMany(r => r.CreatedRentPayments)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RentPayment_User");
    }
}