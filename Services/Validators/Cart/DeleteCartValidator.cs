using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
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
    public class DeleteCartValidator : AbstractValidator<DeleteCartRequest>
    {
        private readonly DBContext _db;

        public DeleteCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CartID).MustAsync(IsValidID).WithMessage("Data Does Not Exist");
        }

        private async Task<bool> IsValidID(Guid id, CancellationToken cancellationToken)
        {
            var data = await _db.Carts.Where(Q => Q.CartID == id)
                .AnyAsync();

            if (!data)
            {
                return false;
            }
            return true;
        }
    }
}
