using Application.Common;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Common;
public class BugService : IBugService
{

    private readonly AppDbContext _context;

    public BugService(AppDbContext context) => _context = context;


    public async Task<Bug> CreateBugAsync(Bug bug)
    {
        await _context.Bugs.AddAsync(bug);
        await _context.SaveChangesAsync();
        return bug;
    }

    public async Task<bool> DeleteBugAsync(int id)
    {
        var bug = await _context.Bugs.FindAsync(id);
        _context.Bugs.Remove(bug);
        var hasChanges = await _context.SaveChangesAsync();

        return hasChanges > 0;
    }

    public IEnumerable<Bug> GetAllBugs()
    {
        return _context.Bugs.AsEnumerable();
    }

    public async Task<Bug?> GetBugAsync(int id)
    {
        return await _context.Bugs.FindAsync(id);
    }

    public Task<Bug> UpdateBugAsync(int id, Bug bug)
    {
        throw new NotImplementedException(); // TODO UpdateBugAsync Function
    }
}
