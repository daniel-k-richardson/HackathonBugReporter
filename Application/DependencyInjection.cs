using Application.Common.Dtos;
using Application.Common.Validation;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, ServiceLifetime.Scoped);

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            .AddValidation<DeleteUserCommand, bool>()
            .AddValidation<CreateUserCommand, User>());

        services.AddAutoMapper(typeof(DependencyInjection));


        return services;
    }
}
