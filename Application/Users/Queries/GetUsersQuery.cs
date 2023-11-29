using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries;
public record GetUsersQuery : IRequest<Result<IList<GlobalUser>>>;
