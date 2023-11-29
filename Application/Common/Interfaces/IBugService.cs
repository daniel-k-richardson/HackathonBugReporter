using Domain.Entities;

namespace Application.Common.Interfaces;
public interface IBugService
{
    IEnumerable<Bug> GetAllBugs();
    Task<Bug?> GetBugAsync(int id);
    Task<Bug> CreateBugAsync(Bug bug);
    Task<Bug> UpdateBugAsync(int id, Bug bug);
    Task<bool> DeleteBugAsync(int id);
}
