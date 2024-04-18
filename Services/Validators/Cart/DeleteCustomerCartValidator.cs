using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class DeleteCustomerCartValidator : AbstractValidator<DeleteCustomerRequest>
    {
        private readonly DBContext _db;

        public DeleteCustomerCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).MustAsync(IsCartExist).WithMessage("Cart item not exist.");
        }

        private async Task<bool> IsCartExist(Guid cartID, CancellationToken cancellationToken)
        {
            var isCartExist = await _db.Carts.Where(Q => Q.CartID == cartID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isCartExist;
        }
    }
}
