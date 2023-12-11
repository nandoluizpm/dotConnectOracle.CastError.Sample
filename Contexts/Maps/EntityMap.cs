using DotConnectOracle.CastError.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotConnectOracle.CastError.Sample.Contexts.Maps;

public class EntityMap : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder.ToTable("ENTITYTABLE");
        
        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id)
            .HasColumnName("IDFIELD");
        
        builder.Property(x => x.Unused)
            .HasConversion(p => p.Value, value => value)
            .HasColumnName("USAGEFLAG")
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
    }
}