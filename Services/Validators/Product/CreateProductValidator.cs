using Contracts.RequestModels.Product;
using FluentValidation;

namespace Services.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Price).NotNull().WithMessage("Price cannot be empty.");
        }
    }
}
