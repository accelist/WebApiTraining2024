using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Customer
{
    public class GetCustomerByIdValidator : AbstractValidator<GetCustomerDataByIdRequest>
    {
        private readonly DBContext _db;
        public GetCustomerByIdValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerId).NotEmpty().WithMessage("Please enter customer ID")
                .MustAsync(AvailableId).WithMessage("Id is not exist");
        }

        private async Task<bool> AvailableId(Guid? customerId, CancellationToken token)
        {
            var isIdExist = await _db.Customers.Where(Q => Q.CustomerID == customerId).AsNoTracking().AnyAsync();
            return isIdExist;
        }
    }
}
