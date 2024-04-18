using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Customer
{
    public class GetCustomerDetailValidator : AbstractValidator<CustomerDetailRequest>
    {
        private readonly DBContext _db;

        public GetCustomerDetailValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).MustAsync(IsCustomerExist).WithMessage("Customer not exist.");
        }

        private async Task<bool> IsCustomerExist(Guid customerID, CancellationToken cancellationToken)
        {
            var isCustomerExist = await _db.Customers.Where(Q => Q.CustomerID == customerID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return isCustomerExist;
        }
    }
}
