using AluguelRV.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AluguelRV.Core.Data.EntityConfig;
public class RentEntityConfig : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.ToTable("Rent");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).IsUnicode();
        builder.Property(x => x.Month).IsRequired();
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.Amount).HasColumnType("smallmoney").IsRequired().HasDefaultValue(0);
        builder.Property(x => x.Percentage).IsRequired().HasDefaultValue(52).HasColumnType("decimal(5, 2)");
        builder.Property(x => x.Closed).IsRequired().HasDefaultValue(false);
        builder.Property(x => x.Deleted).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.Timestamp).HasDefaultValueSql("(getutcdate())");
    }
}