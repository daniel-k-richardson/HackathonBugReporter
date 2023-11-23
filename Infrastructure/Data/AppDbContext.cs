namespace Infrastructure.Data;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Bug> Bugs { get; set; }
    public DbSet<GlobalUser> GlobalUsers { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
