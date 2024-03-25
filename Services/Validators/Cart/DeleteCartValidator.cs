using Contracts.RequestModels.Cart;
using FluentValidation;

namespace Services.Validators.Cart
{
    public class DeleteCartValidator : AbstractValidator<DeleteCartDataRequest>
    {
        public DeleteCartValidator()
        {
            RuleFor(Q => Q.CartId).NotEmpty().WithMessage("Customer ID Can't Be Empty!");
        }
    }
}
