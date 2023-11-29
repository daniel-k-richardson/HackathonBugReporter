using Application.Common.Interfaces;
using Application.Users.Queries;
using AutoMapper;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Events
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, Result<GlobalUser>>
    {
        private readonly IUserService _context;
        private readonly IMapper _mapper;

        public GetUserHandler(IUserService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Result<GlobalUser>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return  _context.GetUserAsync(request.UserId);
        }
    }
}
