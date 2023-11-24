using Application.Common;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Common;
public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context) => _context = context;

    public async Task<GlobalUser> CreateUserAsync(GlobalUser user)
    {
        await _context.GlobalUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.GlobalUsers.FindAsync(id);
        _context.GlobalUsers.Remove(user);
        var hasChanges = await _context.SaveChangesAsync();

        return hasChanges > 0;
    }

    public IEnumerable<GlobalUser> GetAllUsers()
    {
        return _context.GlobalUsers.AsEnumerable();
    }

    public async Task<GlobalUser?> GetUserAsync(int id)
    {
        return await _context.GlobalUsers.FindAsync(id);
    }

    public Task<GlobalUser> UpdateUserAsync(int id, GlobalUser user) => throw new NotImplementedException();
}
