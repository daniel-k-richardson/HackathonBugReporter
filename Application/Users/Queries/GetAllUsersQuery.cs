using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries;
public class GetAllUsersQuery : IRequest<Result<IList<GlobalUser>>>
{
    public GetAllUsersQuery()
    {
    }
}
