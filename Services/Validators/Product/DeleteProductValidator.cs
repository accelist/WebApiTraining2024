
using Contracts.RequestModels.Product;
using FluentValidation;


namespace Services.Validators.Product
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductDataRequest>
    {

        public DeleteProductValidator()
        {

            //RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name Can't be Empty!")
            //    .MaximumLength(20).WithMessage("Maximum Name's Length 20 Characters!");

            //RuleFor(Q => Q.Email).EmailAddress().NotEmpty().WithMessage("Email Can't Be Empty!");

            RuleFor(Q => Q.ProductID).NotEmpty().WithMessage("CustomerID Can't Be Empty!");

        }
    }
}
