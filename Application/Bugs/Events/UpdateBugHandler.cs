using Application.Bugs.Commands;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Bugs.Events;
public class UpdateBugHandler : IRequestHandler<UpdateBugCommand, Bug>
{
    private readonly IBugService _bugService;

    public UpdateBugHandler(IBugService bugService) => _bugService = bugService;

    public async Task<Bug> Handle(UpdateBugCommand request, CancellationToken cancellationToken)
    {
        var user = await _bugService.UpdateBugAsync(request.BugId, request.bug);

        return user ?? new();
    }
}
