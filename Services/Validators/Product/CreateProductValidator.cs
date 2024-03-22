
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
            RuleFor(Q => Q.Name).NotEmpty().MaximumLength(50);
            RuleFor(Q => Q.Price).NotEmpty().GreaterThanOrEqualTo(10000);
        }

    }
}
