using Application.Bugs.Commands;
using Application.Common;
using MediatR;

namespace Application.Bugs.Events;
public class DeleteBugHandler : IRequestHandler<DeleteBugCommand, bool>
{
    private readonly IBugService _bugService;

    public DeleteBugHandler(IBugService bugService) => _bugService = bugService;

    public async Task<bool> Handle(DeleteBugCommand request, CancellationToken cancellationToken)
    {
        var result = await _bugService.DeleteBugAsync(request.bugId);
        return result;
    }
}
