using Application.Common.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries;
public record GetUsersQuery : IRequest<Result<IList<User>>>;
