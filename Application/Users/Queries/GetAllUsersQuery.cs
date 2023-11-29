using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries;
public record GetAllUsersQuery : IRequest<Result<IList<GlobalUser>>>;
