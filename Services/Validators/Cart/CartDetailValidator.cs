
using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class CartDetailValidator : AbstractValidator<CartDetailRequest>
    {
        private readonly DBContext _db;
        public CartDetailValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.CartId).MustAsync(CartIdExists).WithMessage("Cart ID not found.");
        }

        public async Task<bool> CartIdExists(Guid id, CancellationToken cancellationToken)
        {
            bool response = await _db.Carts.Where(Q => Q.CartID == id).AsNoTracking().AnyAsync(cancellationToken);
            return response;
        }
    }
}
