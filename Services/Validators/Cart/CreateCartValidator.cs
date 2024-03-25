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
    public class CreateCartValidator : AbstractValidator<CreateCartRequest>
    {
        private readonly DBContext _db;

        public CreateCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductID).NotEmpty().WithMessage("Name cannot be empty.");

            RuleFor(Q => Q.CustomerID).NotEmpty().WithMessage("Name cannot be empty.");
        }
    }
}
