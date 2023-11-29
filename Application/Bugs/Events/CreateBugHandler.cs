using Application.Bugs.Commands;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Bugs.Events;
public class CreateBugHandler : IRequestHandler<CreateBugCommand, Bug>
{
    private readonly IBugService _bugService;

    public CreateBugHandler(IBugService bugService) => _bugService = bugService;

    public async Task<Bug> Handle(CreateBugCommand request, CancellationToken cancellationToken)
    {
        var result = await _bugService.CreateBugAsync(request.BugRequest);
        return result;
    }
}
