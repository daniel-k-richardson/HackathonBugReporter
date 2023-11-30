using Application.Bugs.Commands;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Bugs.Events;
public class CreateBugHandler : IRequestHandler<CreateBugCommand, Bug>
{
    private readonly IAppDbContext _context;

    public CreateBugHandler(IAppDbContext context) => _context = context;

    public async Task<Bug> Handle(CreateBugCommand request, CancellationToken cancellationToken)
    {
        await _context.Bugs.AddAsync(request.BugRequest);
        await _context.SaveChangesAsync();

        return request.BugRequest;
    }
}
