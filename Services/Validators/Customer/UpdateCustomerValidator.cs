using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Contracts.RequestModels.Customer;

namespace Services.Validators.Customer
{
    public class UpdateCustomerValidator: AbstractValidator<UpdateCustomerRequest>
    {
        private readonly DBContext _db;

        public UpdateCustomerValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.CustomerID).NotEmpty().WithMessage("Customer ID cannot be empty").MustAsync(CheckID).WithMessage("Customer ID cannot be found!");

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Email).EmailAddress()
                .NotEmpty().WithMessage("Email cannot be empty.")
                .MustAsync(BeAvailableEmail).WithMessage("Email already exists.");
        }

        public async Task<bool> BeAvailableEmail(string email, CancellationToken cancellationToken)
        {
            var isEmailExist = await _db.Customers.Where(Q => Q.Email == email)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isEmailExist;
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
