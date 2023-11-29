using Application.Common.Interfaces;
using Application.Users.Commands.DeleteUser;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Events;
public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<bool>>
{
    private readonly IAppDbContext _context;

    public DeleteUserHandler(IAppDbContext context) 
        => _context = context;

    public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.GlobalUsers.FindAsync(request.userId, cancellationToken);
        _context.GlobalUsers.Remove(user!);

        try
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        catch (DbUpdateException ex)
        {
            return new Result<bool>(ex);
        }
    }
}
