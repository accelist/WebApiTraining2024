using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Cart
{
    public class UpdateCartValidator: AbstractValidator<UpdateCartRequest>
    {
        private readonly DBContext _db;

        public UpdateCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CartID)
                .NotEmpty().WithMessage("CartID cannot be empty.")
                .MustAsync(CheckIDCart).WithMessage("Cart ID cannot be found!");
            RuleFor(Q => Q.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be minus.");
        }

        public async Task<bool> CheckIDCart(Guid id, CancellationToken cancellationToken)
        {
            var idExist = await _db.Carts.Where(Q => Q.CartID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return idExist;
        }
    }
}
