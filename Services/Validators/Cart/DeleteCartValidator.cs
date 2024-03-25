using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class DeleteCartValidator : AbstractValidator<DeleteCartRequest>
    {
        private readonly DBContext _db;
        public DeleteCartValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.CartId)
                .NotEmpty().WithMessage("ID Can't be Empty")
                .MustAsync((id, cancellationToken) => BeAvailableId(id, cancellationToken)).WithMessage("ID not Exist");
        }

        public async Task<bool> BeAvailableId(Guid? id, CancellationToken cancellationToken)
        {
            var existingId = await _db.Carts.Where(Q => Q.CartID == id)
                .AsNoTracking().AnyAsync(cancellationToken);

            return existingId;
        }
    }
}
