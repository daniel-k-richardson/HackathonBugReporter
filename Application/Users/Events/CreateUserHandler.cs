using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<User>>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public CreateUserHandler(
        IMapper mapper,
        IAppDbContext appDbContext)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    public async Task<Result<User>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<GlobalUser>(request.User);
        var result = await _appDbContext.GlobalUsers.AddAsync(user, cancellationToken);
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<User>(result);
    }
}
