
using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Customer
{
    public class CustomerDetailValidator : AbstractValidator<CustomerDetailRequest>
    {
        private readonly DBContext _db;
        public CustomerDetailValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).NotEmpty().MustAsync(CustomerIDExists).WithMessage("Customer ID does not exist.");
        }
        private async Task<bool> CustomerIDExists(Guid id, CancellationToken cancellationToken)
        {
            var customerIDExists = await _db.Customers.Where(Q => Q.CustomerID == id).AsNoTracking().AnyAsync(cancellationToken);
            return customerIDExists;
        }
    }
}
