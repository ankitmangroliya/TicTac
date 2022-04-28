using FluentValidation;

namespace TicTac.WebAPI.Models
{
    public class RequestModelValidator : AbstractValidator<RequestModel>
    {
        public RequestModelValidator()
        {
            RuleFor(model => model.number)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .InclusiveBetween(1, 1000).WithMessage("Number must be Beetween 1, 1000.");
        }
    }
}
