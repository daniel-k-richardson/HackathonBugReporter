using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;


public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Bug> Bugs => Set<Bug>();
    public DbSet<GlobalUser> GlobalUsers => Set<GlobalUser>();
    public DbSet<Comment> Comments => Set<Comment>();

    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
}
