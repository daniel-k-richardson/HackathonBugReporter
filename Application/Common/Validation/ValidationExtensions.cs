using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Validation;
public static class ValidationExtensions
{
    public static MediatRServiceConfiguration AddValidation<TRequest, TResult>(this MediatRServiceConfiguration config) where TRequest : notnull
    {
        return config.AddBehavior<IPipelineBehavior<TRequest, Result<TResult>>, ValidationBehavior<TRequest, TResult>>();
    }
}
