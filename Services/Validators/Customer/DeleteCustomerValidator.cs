using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Customer
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerDataRequest>
    {
        private readonly DBContext _db;
        public DeleteCustomerValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerId).NotEmpty().WithMessage("Id not found")
                .MustAsync(AvailableId).WithMessage("Id is not exist");
        }

        private async Task<bool> AvailableId(Guid? customerId, CancellationToken token)
        {
            var isIdExist = await _db.Customers.Where(Q => Q.CustomerID == customerId).AsNoTracking().AnyAsync();
            return isIdExist;
        }
    }
}
