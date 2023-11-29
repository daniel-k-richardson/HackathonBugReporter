using Application.Common.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands.CreateUser;
public record CreateUserCommand(User User) : IRequest<Result<User>>;
