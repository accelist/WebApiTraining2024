using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class DeleteCartByIdValidator : AbstractValidator<DeleteCartRequest>
    {
        private readonly DBContext _db;

        public DeleteCartByIdValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Id).NotEmpty().WithMessage("ID cannot be empty.")
                .MustAsync(ExistingID).WithMessage("ID does not exist.");
        }

        private async Task<bool> ExistingID(Guid id, CancellationToken cancellationToken)
        {
            var existingID = await _db.Carts
                .Where(Q => Q.CartID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return existingID;
        }
    }
}
