using Application.Common;
using Application.Users.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Users.Events;
public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, GlobalUser>
{

    private readonly IUserService _userService;

    public UpdateUserRequestHandler(IUserService userService) => _userService = userService;

    public async Task<GlobalUser> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.UpdateUserAsync(request.UserId, request.User);

        return user ?? new();
    }
}
