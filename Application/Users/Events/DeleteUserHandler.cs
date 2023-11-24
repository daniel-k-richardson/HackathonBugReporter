using Application.Common;
using Application.Users.Commands;
using MediatR;

namespace Application.Users.Events;
public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, bool>
{
    private readonly IUserService _userService;

    public DeleteUserHandler(IUserService userService) => _userService = userService;

    public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userService.DeleteUserAsync(request.userId);
        return result;
    }
}
