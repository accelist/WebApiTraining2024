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
    public class CreateCartValidator : AbstractValidator<CreateCartRequest>
    {
        private readonly DBContext _db;

        public CreateCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Quantity).NotEmpty().WithMessage("Quantity cannot be empty.");

            RuleFor(Q => Q.ProductID)
                .NotEmpty().WithMessage("ProductID cannot be empty.")
                .MustAsync(CheckIDProducts).WithMessage("Product ID cannot be found!");
            RuleFor(Q => Q.CustomerID)
                .NotEmpty().WithMessage("CustomerID cannot be empty.")
                .MustAsync(CheckIDCustomer).WithMessage("Customer ID cannot be found!");
        }

        public async Task<bool> CheckIDProducts(Guid id, CancellationToken cancellationToken)
        {
            var idExist = await _db.Products.Where(Q => Q.ProductID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return idExist;
        }

        public async Task<bool> CheckIDCustomer(Guid id, CancellationToken cancellationToken)
        {
            var idExist = await _db.Customers.Where(Q => Q.CustomerID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return idExist;
        }
    }
}
