using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands.UpdateUser;
public record UpdateUserCommand(int UserId, GlobalUser User) : IRequest<Result<GlobalUser>>;
