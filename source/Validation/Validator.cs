using DotNetCore.Objects;
using FluentValidation;
using System.Linq;

namespace DotNetCore.Validation
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        protected Validator()
        {
        }

        protected Validator(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        private string ErrorMessage { get; set; }

        public IResult Valid(T instance)
        {
            if (Equals(instance, default(T)))
            {
                return new ErrorResult(ErrorMessage);
            }

            var result = Validate(instance);

            if (result.IsValid)
            {
                return new SuccessResult();
            }

            ErrorMessage = ErrorMessage ?? string.Join(" ", result.Errors.Select(x => x.ErrorMessage));

            return new ErrorResult(ErrorMessage);
        }
    }
}
