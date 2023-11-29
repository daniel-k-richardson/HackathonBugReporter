using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Validation;
public class ValidationBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, Result<TResult>> 
    where TRequest : notnull
{

    private readonly IValidator<TRequest> _validator;

    public ValidationBehavior(IValidator<TRequest> validator) => _validator = validator;

    public async Task<Result<TResult>> Handle(
        TRequest request,
        RequestHandlerDelegate<Result<TResult>> next,
        CancellationToken cancellationToken)
    {
        var validationResults = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResults.IsValid)
        {
            return new Result<TResult>(new ValidationException(validationResults.Errors));
        }

        return await next();
    }
}
