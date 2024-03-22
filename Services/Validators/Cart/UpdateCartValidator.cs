
using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class UpdateCartValidator : AbstractValidator<UpdateCartRequest>
    {
        private readonly DBContext _db;
        public UpdateCartValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.CartId).NotEmpty().MustAsync(CartIdExists).WithMessage("Cart ID not found.");
            RuleFor(Q => Q.Quantity).GreaterThanOrEqualTo(0);

        }
        public async Task<bool> CartIdExists(Guid id, CancellationToken cancellationToken)
        {
            bool response = await _db.Carts.Where(Q => Q.CartID == id).AsNoTracking().AnyAsync(cancellationToken);
            return response;
        }
    }
}
