using Application.Common.Interfaces;
using Domain.Entities;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Common;
public class UserService : IUserService
{
    private readonly IAppDbContext _context;

    public UserService(IAppDbContext context) => _context = context;

    public async Task<Result<GlobalUser>> CreateUserAsync(GlobalUser user)
    {
        await _context.GlobalUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<Result<bool>> DeleteUserAsync(int id)
    {
        var user = await _context.GlobalUsers.FindAsync(id);
        _context.GlobalUsers.Remove(user!);

        var hasChanges = await _context.SaveChangesAsync();
        return hasChanges > 0;
    }

    public async Task<Result<IList<GlobalUser>>> GetAllUsersAsync()
    {
        var result = await _context.GlobalUsers.ToListAsync();

        return result;
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
