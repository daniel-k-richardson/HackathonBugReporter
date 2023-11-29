using Domain.Entities;
using LanguageExt.Common;

namespace Application.Common.Interfaces;
public interface IUserService
{
    Task<Result<IList<GlobalUser>>> GetAllUsersAsync();
    Task<Result<GlobalUser?>> GetUserAsync(int id);
    Task<Result<GlobalUser>> CreateUserAsync(GlobalUser user);
    Task<Result<GlobalUser?>> UpdateUserAsync(int id, GlobalUser user);
    Task<Result<bool>> DeleteUserAsync(int id);
}
