using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;

namespace Services.Validators.Cart
{
    public class UpdateCartValidator : AbstractValidator<UpdateCartRequest>
    {
        private readonly DBContext _db;

        public UpdateCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Quantity).GreaterThan(-1).WithMessage("Quantity cannot be below 0.");
        }
    }
}
