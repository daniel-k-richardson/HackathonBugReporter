using Application.Bugs.Commands;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Bugs.Events;
public class DeleteBugHandler : IRequestHandler<DeleteBugCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeleteBugHandler(IAppDbContext context) => _context = context;

    public async Task<bool> Handle(DeleteBugCommand request, CancellationToken cancellationToken)
    {
        var bug = await _context.Bugs.FindAsync(request.bugId);
        _context.Bugs.Remove(bug);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}
