using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        private readonly DBContext _db;
        public UpdateProductValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Price).NotEmpty().WithMessage("Price cannot be empty.")
                .GreaterThanOrEqualTo(10000).WithMessage("Price at least 10000");
        }
    }
}
