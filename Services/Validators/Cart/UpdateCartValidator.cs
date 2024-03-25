using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;


namespace Services.Validators.Cart
{
    public class UpdateCartValidator : AbstractValidator<UpdateCartDataRequest>
    {
        private readonly DBContext _db;
        public UpdateCartValidator(DBContext db)
        {
            _db = db;
            

            RuleFor(Q => Q.Quantity).NotEmpty().WithMessage("Quantity Can't be Empty!")
                .GreaterThanOrEqualTo(0).WithMessage("Can't be 0 or negative");

        }
    }
}
