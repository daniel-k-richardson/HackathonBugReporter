using Application.Common.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands.UpdateUser;
public record UpdateUserCommand(int UserId, User User) : IRequest<Result<User>>;
