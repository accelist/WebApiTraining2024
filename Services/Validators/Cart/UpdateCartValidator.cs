using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Cart
{
    public class UpdateCartValidator : AbstractValidator<UpdateCartRequest>
    {
        private readonly DBContext _db;
        public UpdateCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than 0 or Item Deleted.");
        }
    }
}
