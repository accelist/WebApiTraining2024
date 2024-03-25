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
            RuleFor(Q => Q.CartId).NotEmpty().WithMessage("Cart id Can't be Empty")
                .MustAsync((id, cancellationToken) => BeAvailableId(id, cancellationToken));

            RuleFor(Q => Q.Quantity)
               .NotEmpty().WithMessage("Quantity cannot be empty.")
               .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }

        public async Task<bool> BeAvailableId(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
                return false;

            var existingId = await _db.Carts
                .AsNoTracking()
                .AnyAsync(Q => Q.CartID == id, cancellationToken);

            return existingId;
        }
    }
}
