using CodeInspector.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeInspector.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Repository> Repositories => Set<Repository>();

    public DbSet<Scan> Scans => Set<Scan>();

    public DbSet<Issue> Issues => Set<Issue>();

    public DbSet<Report> Reports => Set<Report>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}