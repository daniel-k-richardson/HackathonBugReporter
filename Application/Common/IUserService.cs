using Domain.Entities;

namespace Application.Common;
public interface IUserService
{
    IEnumerable<GlobalUser> GetAllUsers();
    Task<GlobalUser?> GetUserAsync(int id);
}
