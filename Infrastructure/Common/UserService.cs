using Application.Common;
using Domain.Entities;
using Infrastructure.Data;
using LanguageExt.Common;
using System.Data.Entity;

namespace Infrastructure.Common;
public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context) => _context = context;

    public async Task<Result<GlobalUser>> CreateUserAsync(GlobalUser user)
    {
        await _context.GlobalUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<Result<bool>> DeleteUserAsync(int id)
    {
        var user = await _context.GlobalUsers.FindAsync(id);

        if (user is null)
        {
            var error = new ArgumentException("User not found", nameof(id));
            return new Result<bool>(error);
        }

        _context.GlobalUsers.Remove(user);
        var hasChanges = await _context.SaveChangesAsync();

        return hasChanges > 0;
    }

    public async Task<Result<IList<GlobalUser>>> GetAllUsersAsync()
    {
        return await _context.GlobalUsers.ToListAsync();
    }

    public async Task<Result<GlobalUser?>> GetUserAsync(int id)
    {
        return await _context.GlobalUsers.FindAsync(id);
    }

    public async Task<Result<GlobalUser?>> UpdateUserAsync(int id, GlobalUser user)
    {
        var existingUser = await _context.GlobalUsers.FindAsync(user.Id);
        if(existingUser is null) 
        {
            return default(GlobalUser);
        }

        _context.GlobalUsers.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
