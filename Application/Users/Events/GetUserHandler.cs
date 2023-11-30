using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Users.Queries;
using AutoMapper;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, Result<User?>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetUserHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<User?>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.GlobalUsers.FindAsync(request.UserId, cancellationToken);
            return _mapper.Map<User>(user);
        }
    }
}
