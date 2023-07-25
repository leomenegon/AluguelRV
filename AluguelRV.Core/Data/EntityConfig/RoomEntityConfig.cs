using AluguelRV.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Core.Data.EntityConfig;
public class RoomEntityConfig : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("Room");

        builder.Property(e => e.Name).HasMaxLength(50);
        builder.Property(e => e.Percentage).HasColumnType("decimal(5, 2)");
        builder.Property(e => e.Timestamp).HasDefaultValueSql("(getutcdate())");
    }
}