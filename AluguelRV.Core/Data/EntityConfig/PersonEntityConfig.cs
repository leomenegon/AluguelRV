using AluguelRV.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Core.Data.EntityConfig;
public class PersonEntityConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityColumn();

        builder.Property(e => e.Name).IsRequired().IsUnicode();
        builder.Property(e => e.Resident).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.DefaultRoom);
        builder.Property(e => e.Deleted).HasDefaultValue(false);
    }
}
