using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;
public interface IAppDbContext : IDisposable
{
    DbSet<GlobalUser> GlobalUsers { get; }
    DbSet<Bug> Bugs { get; }
    DbSet<Comment> Comments { get; }

    Task<int> SaveChangesAsync();
}