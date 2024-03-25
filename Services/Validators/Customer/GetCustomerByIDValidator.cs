using System.Threading;
using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Customer
{
    public class GetCustomerByIDValidator : AbstractValidator<GetCustomerRequest>
    {
        private readonly DBContext _db;

        public GetCustomerByIDValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerId).NotEmpty().WithMessage("ID cannot be empty.")
                .MustAsync(ExistingID).WithMessage("ID does not exist.");
        }

        private async Task<bool> ExistingID(Guid id, CancellationToken cancellationToken)
        {
            var existingID = await _db.Customers
                .Where(Q => Q.CustomerID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return existingID;
        }
    }
}
