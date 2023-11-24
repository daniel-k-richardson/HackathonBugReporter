
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;
public class CreateUserRequest : IRequest<GlobalUser>
{

    public GlobalUser UserRequest { get; }

    public CreateUserRequest(GlobalUser userRequest)
    {
        UserRequest = userRequest;
    }
}
