using AluguelRV.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Core.Data.EntityConfig;
public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("User");

        builder.HasIndex(e => e.Username, "UQ__User__536C85E4057B524C").IsUnique();

        builder.Property(e => e.Password)
            .HasMaxLength(64)
            .IsFixedLength();

        builder.Property(e => e.Salt)
            .HasMaxLength(128)
            .IsFixedLength();

        builder.Property(e => e.Username).HasMaxLength(50);

        builder.HasOne(d => d.Person).WithMany(p => p.Users)
            .HasForeignKey(d => d.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_User_Person");

        builder.HasMany(d => d.Expenses).WithOne(p => p.User)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_User_Person");
    }
}