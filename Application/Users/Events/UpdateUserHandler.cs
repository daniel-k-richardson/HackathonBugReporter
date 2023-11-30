using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Users.Commands.UpdateUser;
using AutoMapper;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events;
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<User>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        GlobalUser globalUser = await _context.GlobalUsers.FindAsync(request.UserId, cancellationToken);
        var update = _mapper.Map(request.User, globalUser);

        _context.GlobalUsers.Update(update);
        await _context.SaveChangesAsync();

        return _mapper.Map<User>(update);
    }
}
