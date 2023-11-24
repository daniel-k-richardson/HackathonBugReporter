using Domain.Entities;
using MediatR;


namespace Application.Bugs.Queries;
public class GetAllBugsQuery : IRequest<IEnumerable<Bug>>
{
    public GetAllBugsQuery() 
    {
    }
}

