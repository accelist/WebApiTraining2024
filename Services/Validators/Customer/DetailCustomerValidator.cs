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
    public class DetailCustomerValidator: AbstractValidator<CustomerDetailRequest>
    {
        private readonly DBContext _db;

        public DetailCustomerValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).NotEmpty().WithMessage("Customer ID cannot be empty").MustAsync(CheckID).WithMessage("Customer ID cannot be found!");
        }

        public async Task<bool> CheckID(Guid? id, CancellationToken cancellationToken)
        {
            var idExist = await _db.Customers.Where(Q => Q.CustomerID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return idExist;
        }
    }
}
