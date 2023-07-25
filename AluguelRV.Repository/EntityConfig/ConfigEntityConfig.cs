using AluguelRV.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelRV.Repository.EntityConfig;
public class ConfigEntityConfig : IEntityTypeConfiguration<Config>
{
    public void Configure(EntityTypeBuilder<Config> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("Config");

        builder.Property(e => e.Description).HasMaxLength(50);
        builder.Property(e => e.Key).HasMaxLength(10);
        builder.Property(e => e.Value).HasMaxLength(50);
    }
}