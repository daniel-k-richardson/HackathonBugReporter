using Domain.Entities;

namespace Application.Common;
public interface IUserService
{
    IEnumerable<GlobalUser> GetAllUsers();
    Task<GlobalUser?> GetUserAsync(int id);
    Task<GlobalUser> CreateUserAsync(GlobalUser user);
    Task<GlobalUser> UpdateUserAsync(int id, GlobalUser user);
    Task<bool> DeleteUserAsync(int id);
}
