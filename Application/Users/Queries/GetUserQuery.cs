using Application.Common.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries;
public record GetUserQuery(int UserId) : IRequest<Result<User?>>;
