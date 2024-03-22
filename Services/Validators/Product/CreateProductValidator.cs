using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Product
{
    public class CreateProductValidator: AbstractValidator<CreateProductRequest>
    {
        private readonly DBContext _db;

        public CreateProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Price)
                .NotEmpty().WithMessage("Price cannot be empty.")
                .GreaterThanOrEqualTo(10000).WithMessage("Price must be atleast 10000");
        }

        public async Task<bool> BeAvailableName(string name, CancellationToken cancellationToken)
        {
            var isNameExist = await _db.Products.Where(Q => Q.Name == name)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isNameExist;
        }
    }
}
