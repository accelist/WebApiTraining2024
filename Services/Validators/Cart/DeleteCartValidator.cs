using Contracts.RequestModels.Cart;
using FluentValidation;


namespace Services.Validators.Cart
{
    public class DeleteCartValidator : AbstractValidator<DeleteCartRequest>
    {
        public DeleteCartValidator()
        {
            RuleFor(Q => Q.CartID).NotEmpty().WithMessage("Customer ID Can't Be Empty!");
        }
    }
}
