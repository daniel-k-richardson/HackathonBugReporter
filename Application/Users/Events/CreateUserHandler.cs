using Application.Common;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Users.Events;
public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, GlobalUser>
{
    private readonly IUserService _userService;

    public CreateUserRequestHandler(IUserService userService) => _userService = userService;

    public async Task<GlobalUser> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateUserAsync(request.UserRequest);
        return result;
    }
}
