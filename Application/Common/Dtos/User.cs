using AutoMapper;
using Domain.Entities;

namespace Application.Common.Dtos;
public class User
{
    public int Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public Guid GlobalIdentity { get; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, GlobalUser>().ReverseMap();
        }
    }
}
