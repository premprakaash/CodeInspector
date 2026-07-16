using CodeInspector.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeInspector.Data.Configurations;

public class ScanConfiguration : IEntityTypeConfiguration<Scan>
{
    public void Configure(EntityTypeBuilder<Scan> builder)
    {
        builder.ToTable("Scans");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(x => x.Issues)
            .WithOne(x => x.Scan)
            .HasForeignKey(x => x.ScanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}