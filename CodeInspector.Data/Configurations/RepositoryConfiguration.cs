using CodeInspector.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeInspector.Data.Configurations;

public class RepositoryConfiguration : IEntityTypeConfiguration<Repository>
{
    public void Configure(EntityTypeBuilder<Repository> builder)
    {
        builder.ToTable("Repositories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.FullName)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Url)
            .HasMaxLength(500);

        builder.Property(x => x.DefaultBranch)
            .HasMaxLength(100);

        builder.HasMany(x => x.Scans)
            .WithOne(x => x.Repository)
            .HasForeignKey(x => x.RepositoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}