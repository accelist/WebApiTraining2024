using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
namespace Services.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        private readonly DBContext _db;
        public UpdateCustomerValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerId).NotEmpty().MustAsync(CustomerIDExists).WithMessage("Customer ID does not exist.");

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Name can only have up to 50 characters.");

            RuleFor(Q => Q.Email).EmailAddress()
                .NotEmpty().WithMessage("Email cannot be empty.")
                .MustAsync(CheckAvailableEmail).WithMessage("Email already used.");
        }

        private async Task<bool> CustomerIDExists(Guid id, CancellationToken cancellationToken)
        {
            var customerIDExists = await _db.Customers.Where(Q => Q.CustomerID == id).AsNoTracking().AnyAsync(cancellationToken);
            return customerIDExists;
        }
        private async Task<bool> CheckAvailableEmail(string email, CancellationToken cancellationToken)
        {
            var isEmailExist = await _db.Customers.Where(Q => Q.Email == email).AsNoTracking().AnyAsync(cancellationToken);

            return !isEmailExist;
        }
    }
}
