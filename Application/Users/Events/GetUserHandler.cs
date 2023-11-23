using Application.Common;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Users.Events
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, GlobalUser>
    {
        private readonly IUserService _context;

        public GetUserHandler(IUserService context) => _context = context;

        public async Task<GlobalUser?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.GetUserAsync(request.UserId);
            return result;
        }
    }
}
