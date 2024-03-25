using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;

namespace Services.Validators.Cart
{
    public class CreateCartValidator : AbstractValidator<CreateCartRequest>
    {
        private readonly DBContext _db;
        public CreateCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Quantity).NotEmpty().WithMessage("Name cannot be empty.");

            RuleFor(Q => Q.ProductId).NotEmpty().WithMessage("Name cannot be empty.");

            RuleFor(Q => Q.Customerid).NotEmpty().WithMessage("Price cannot be empty.");
        }
    }
}
