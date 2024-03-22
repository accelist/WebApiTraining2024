using Contracts.RequestModels.Cart;
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
    public class CartDetailValidator: AbstractValidator<CartDetailRequest>
    {
        private readonly DBContext _db;

        public CartDetailValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CartID)
                .NotEmpty().WithMessage("CartID cannot be empty.")
                .MustAsync(CheckIDCart).WithMessage("Cart ID cannot be found!");
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
