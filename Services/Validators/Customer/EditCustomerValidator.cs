using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Customer
{
    public class EditCustomerValidator : AbstractValidator<EditCustomerRequest>
    {
        private readonly DBContext _db;

        public EditCustomerValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).MustAsync(IsCustomerExist).WithMessage("Customer not exist.");

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Email).EmailAddress()
                .NotEmpty().WithMessage("Email cannot be empty.")
                .MustAsync(BeAvailableEmail).WithMessage("Email already exists.");
        }

        private async Task<bool> IsCustomerExist(Guid customerID, CancellationToken cancellationToken)
        {
            var isCustomerExist = await _db.Customers.Where(Q => Q.CustomerID == customerID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return isCustomerExist;
        }

        private async Task<bool> BeAvailableEmail(string email, CancellationToken cancellationToken)
        {
            var isEmailExist = await _db.Customers.Where(Q => Q.Email == email)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isEmailExist;
        }
    }
}
