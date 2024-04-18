using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class CreateUpdateCustomerCartValidator : AbstractValidator<CreateUpdateCustomerCartRequest>
    {
        private readonly DBContext _db;

        public CreateUpdateCustomerCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).MustAsync(IsCustomerExist).WithMessage("Customer not exist.");
            RuleFor(Q => Q.ProductID).MustAsync(IsProductExist).WithMessage("Product not exist.");
            RuleFor(Q => Q.Quantity).NotNull().WithMessage("Quantity cannot be empty.")
                .GreaterThan(0).WithMessage("Quantity must be greate than 0.");
        }

        private async Task<bool> IsCustomerExist(Guid customerID, CancellationToken cancellationToken)
        {
            var isCustomerExist = await _db.Customers.Where(Q => Q.CustomerID == customerID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return isCustomerExist;
        }

        private async Task<bool> IsProductExist(Guid productID, CancellationToken cancellationToken)
        {
            var isProductExist = await _db.Products.Where(Q => Q.ProductID == productID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return isProductExist;
        }
    }
}
