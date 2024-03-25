using Contracts.RequestModels.Customer;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Customer
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerRequest>
    {
        private readonly DBContext _db;

        public DeleteCustomerValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).MustAsync(IsValidID).WithMessage("Data Does Not Exist");
        }

        private async Task<bool> IsValidID(Guid id, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.Where(Q => Q.CustomerID == id)
                .AnyAsync();

            if(!data)
            {
                return false;
            }
            return true;
        }

        /*public async Task<bool> BeAvailableEmail(string email, CancellationToken cancellationToken)
        {
            var isEmailExist = await _db.Customers.Where(Q => Q.Email == email)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isEmailExist;
        }*/
    }
}
