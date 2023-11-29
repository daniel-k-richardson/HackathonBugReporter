using Application.Common;
using Application.Users.Commands;
using AutoMapper;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<GlobalUser>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateUserHandler(
        IUserService userService,
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<Result<GlobalUser>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {

        //var user = _mapper.Map<GlobalUser>(request.User);
        return await _userService.CreateUserAsync(request.User);
    }
}
