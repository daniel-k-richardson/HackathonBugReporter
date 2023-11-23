using Application.Common;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Common;
public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context) => _context = context;

    public IEnumerable<GlobalUser> GetAllUsers()
    {
        return _context.GlobalUsers.AsEnumerable();
    }

    public async Task<GlobalUser> GetUserAsync(int id)
    {
        return await _context.GlobalUsers.FindAsync(id) ?? new();
    }
}
