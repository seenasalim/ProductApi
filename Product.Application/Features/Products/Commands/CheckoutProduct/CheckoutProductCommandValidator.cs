using FluentValidation;

namespace Product.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutProductCommandValidator : AbstractValidator<CheckoutProductCommand>
    {
        public CheckoutProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(p => p.Price)
               .NotEmpty().WithMessage("{Price} is required.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{Price} is required.");
        }
    }
}
