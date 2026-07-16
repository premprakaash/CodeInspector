using CodeInspector.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeInspector.Data.Configurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.ToTable("Issues");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RuleId)
            .HasMaxLength(50);

        builder.Property(x => x.RuleName)
            .HasMaxLength(200);

        builder.Property(x => x.Severity)
            .HasMaxLength(30);

        builder.Property(x => x.FileName)
            .HasMaxLength(500);

        builder.Property(x => x.ClassName)
            .HasMaxLength(200);

        builder.Property(x => x.MethodName)
            .HasMaxLength(200);

        builder.Property(x => x.Message)
            .HasColumnType("text");

        builder.Property(x => x.Recommendation)
            .HasColumnType("text");
    }
}