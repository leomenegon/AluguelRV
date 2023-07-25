using AluguelRV.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Repository.EntityConfig;
public class RentRoomPersonEntityConfig : IEntityTypeConfiguration<RentRoomPerson>
{
    public void Configure(EntityTypeBuilder<RentRoomPerson> builder)
    {
        builder
            .HasNoKey()
            .ToTable("RentRoomPerson");

        builder.HasOne(d => d.Person).WithMany()
            .HasForeignKey(d => d.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RentRoomPerson_Person");

        builder.HasOne(d => d.Rent).WithMany()
            .HasForeignKey(d => d.RentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RentRoomPerson_Rent");

        builder.HasOne(d => d.Room).WithMany()
            .HasForeignKey(d => d.RoomId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RentRoomPerson_Room");
    }
}