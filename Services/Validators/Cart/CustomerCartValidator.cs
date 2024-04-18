using Contracts.RequestModels.Cart;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Cart
{
    public class CustomerCartValidator : AbstractValidator<CustomerCartRequest>
    {
        private readonly DBContext _db;

        public CustomerCartValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).MustAsync(IsCustomerExist).WithMessage("Customer not exist.");
        }

        private async Task<bool> IsCustomerExist(Guid customerID, CancellationToken cancellationToken)
        {
            var isCustomerExist = await _db.Customers.Where(Q => Q.CustomerID == customerID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isCustomerExist;
        }
    }
}
