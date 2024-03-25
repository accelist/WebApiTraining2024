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
    public class CreateCartValidator : AbstractValidator<CreateCartRequest>
    {
        private readonly DBContext _db;

        public CreateCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductId).NotEmpty().WithMessage("ProductId cannot be empty.");

            RuleFor(Q => Q.CustomerId).NotEmpty().WithMessage("CustomerId cannot be empty.");

            RuleFor(Q => Q.Quantity).NotEmpty().WithMessage("Quantity cannot be empty.")
                .GreaterThan(0).WithMessage("Must be greater than 0.");

        }
    }
}
