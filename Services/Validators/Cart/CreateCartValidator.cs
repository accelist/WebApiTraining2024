

using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class CreateCartValidator : AbstractValidator<CreateCartRequest>
    {
        private readonly DBContext _db;
        public CreateCartValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(Q => Q.ProductID).NotEmpty().MustAsync(ProductIDExists).WithMessage("Product not found.");
            RuleFor(Q => Q.CustomerID).NotEmpty().MustAsync(CustomerIDExists).WithMessage("Customer not found.");
        }

        public async Task<bool> CustomerIDExists(Guid id, CancellationToken cancellationToken)
        {
            var result = await _db.Customers.Where(Q=>Q.CustomerID == id).AsNoTracking().AnyAsync(cancellationToken);
            return result;
        }
        public async Task<bool> ProductIDExists(Guid id, CancellationToken cancellationToken)
        {
            var result = await _db.Products.Where(Q => Q.ProductID == id).AsNoTracking().AnyAsync(cancellationToken);
            return result;
        }
    }
}
