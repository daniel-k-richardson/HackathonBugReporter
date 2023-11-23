using Application.Common;
using Application.Users.Queries;

namespace Application.Users.Events
{
    public class GetUserHandler : IrequestHandler<GetUserQuery, GlobalUser>
    {
        private readonly IUserService _context;

        public GetUserHandler(IUserService context) => _context = context;

        public async Task<IEnumerable<GlobalUser>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = _context.GetUserAsync();
            return result;
        }
    }
}
