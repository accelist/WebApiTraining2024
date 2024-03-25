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
    public class UpdateProductValidator : AbstractValidator<UpdateProductDataRequest>
    {
        private readonly DBContext _db;
        public UpdateProductValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name Can't be Empty!")
                .MaximumLength(20).WithMessage("Maximum Name's Length 20 Characters!");

            RuleFor(Q => Q.Price).NotEmpty().WithMessage("Price Can't Be Empty!");


        }
    }
}
