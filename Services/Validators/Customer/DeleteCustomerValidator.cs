using Contracts.RequestModels.Customer;
using FluentValidation;

namespace Services.Validators.Customer
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerDataRequest>
    {
        public DeleteCustomerValidator()
        {
            //RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name Can't Be Empty!").MaximumLength(20).WithMessage("Maximum Name's Length 20 Characters");

            //RuleFor(Q => Q.Email).EmailAddress().NotEmpty().WithMessage("Email Can't Be Empty");

            RuleFor(Q => Q.CustomerId).NotEmpty().WithMessage("Customer ID Can't Be Empty!");
        }
    }
}
