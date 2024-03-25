using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;

namespace Services.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly DBContext _db;

        public CreateProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Price).NotEmpty().WithMessage("Price cannot be empty.")
                .LessThan(1000).WithMessage("Price has to be at max 1000");
        }

    }
}
