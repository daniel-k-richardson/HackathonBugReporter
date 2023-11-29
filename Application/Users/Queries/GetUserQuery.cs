using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries;
public record GetUserQuery(int UserId) : IRequest<Result<GlobalUser>>;
