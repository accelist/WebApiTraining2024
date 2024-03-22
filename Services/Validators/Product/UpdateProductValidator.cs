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
    public class UpdateProductValidator: AbstractValidator<UpdateProductRequest>
    {
        private readonly DBContext _db;

        public UpdateProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductID).NotEmpty().WithMessage("Customer ID cannot be empty").MustAsync(CheckID).WithMessage("Product ID cannot be found!");

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Price)
                .NotEmpty().WithMessage("Price cannot be empty.")
                .GreaterThanOrEqualTo(10000).WithMessage("Price must be atleast 10000");
        }

        public async Task<bool> CheckID(Guid? id, CancellationToken cancellationToken)
        {
            var idExist = await _db.Products.Where(Q => Q.ProductID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return idExist;
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
