using Application.Common.Dtos;
using Application.Common.Validation;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, ServiceLifetime.Transient);

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            .AddValidation<DeleteUserCommand, bool>()
            .AddValidation<CreateUserCommand, User>()
            .AddValidation<UpdateUserCommand, User>());

        services.AddAutoMapper(typeof(DependencyInjection));

        return services;
    }
}
