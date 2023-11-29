using Domain.Entities;
using MediatR;


namespace Application.Bugs.Queries;
public class GetBugsQuery : IRequest<IEnumerable<Bug>>
{
    public GetBugsQuery() 
    {
    }
}

