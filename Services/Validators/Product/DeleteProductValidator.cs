using Contracts.RequestModels.Product;
using FluentValidation;

namespace Services.Validators.Product
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductDataRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(Q => Q.ProductId).NotEmpty().WithMessage("Customer ID Can't Be Empty!");
        }
    }
}
