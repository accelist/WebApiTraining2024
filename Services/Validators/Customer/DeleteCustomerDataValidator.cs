using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Customer
{
    public class DeleteCustomerDataValidator : AbstractValidator<DeleteCustomerDataRequest>
    {
        private readonly DBContext _db;

        public DeleteCustomerDataValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.CustomerId).NotEmpty().WithMessage("ID cannot be empty.")
                .MustAsync(ExistingID).WithMessage("ID does not exist.");
        }

        public async Task<bool> ExistingID(Guid id, CancellationToken cancellationToken)
        {
            var existingID = await _db.Customers
                .Where(Q => Q.CustomerID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return existingID;
        }
    }
}
