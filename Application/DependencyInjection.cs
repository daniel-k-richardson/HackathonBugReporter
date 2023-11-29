using Application.Common.Validation;
using Application.Users.Commands;
using Application.Users.Validation;
using FluentValidation;
using LanguageExt.Common;
using MediatR;

using Microsoft.Extensions.DependencyInjection;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<DeleteUserCommandValidator>();

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            .AddBehavior<IPipelineBehavior<DeleteUserCommand, Result<bool>>, ValidationBehavior<DeleteUserCommand, bool>>());

        services.AddAutoMapper(typeof(DependencyInjection));


        return services;
    }
}
