using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Users.Queries;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using System.Data.Entity;

namespace Application.Users.Events;
public class GetUsersHandler : IRequestHandler<GetUsersQuery, Result<IList<User>>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetUsersHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<IList<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.GlobalUsers.ToListAsync();
        return _mapper.Map<List<User>>(result);
    }
}
