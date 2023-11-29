using Application.Common.Validation;
using Application.Users.Commands.DeleteUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<DeleteUserCommandValidator>();

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            .AddValidation<DeleteUserCommand, bool>());

        services.AddAutoMapper(typeof(DependencyInjection));


        return services;
    }
}
