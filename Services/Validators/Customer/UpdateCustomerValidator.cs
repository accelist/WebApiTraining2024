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
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDataRequest>
    {
        private readonly DBContext _db;
        public UpdateCustomerValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name Can't be Empty!")
                .MaximumLength(20).WithMessage("Maximum Name's Length 20 Characters!");

            RuleFor(Q => Q.Email).EmailAddress().NotEmpty().WithMessage("Email Can't Be Empty!")
                .MustAsync(AvailableEmails).WithMessage("The email you give is already exist!");
                
        }

        public async Task <bool> AvailableEmails (string email, CancellationToken cancellationToken)
        {
            var existingEmail = await _db.Customers.Where(Q => Q.Email == email).AsNoTracking().AnyAsync();

            return !existingEmail;
        }

    }
}
