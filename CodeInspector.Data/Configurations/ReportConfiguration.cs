using CodeInspector.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeInspector.Data.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Reports");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.HtmlPath)
            .HasMaxLength(500);

        builder.Property(x => x.PdfPath)
            .HasMaxLength(500);

        builder.HasOne(x => x.Scan)
            .WithMany()
            .HasForeignKey(x => x.ScanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}