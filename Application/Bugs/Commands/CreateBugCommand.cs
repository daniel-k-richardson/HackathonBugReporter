using Domain.Entities;
using MediatR;

namespace Application.Bugs.Commands;
public class CreateBugCommand : IRequest<Bug>
{

    public Bug BugRequest { get; }

    public CreateBugCommand(Bug bugRequest)
    {
        BugRequest = bugRequest;
    }
}
