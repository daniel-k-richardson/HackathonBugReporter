using Domain.Entities;
using MediatR;

namespace Application.Bugs.Queries;
public class GetBugQuery : IRequest<Bug>
{
    public int BugId { get;}

    public GetBugQuery(int bugId)
    {
        BugId = bugId;
    }
}
