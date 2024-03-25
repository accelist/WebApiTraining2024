using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly DBContext _db;

        public CreateProductValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.ProductName).NotEmpty().WithMessage("Product name cannot be empty.")
               .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.ProductPrice)
                .NotEmpty().WithMessage("Price cannot be empty.");
        }

       /* public async Task<bool> BeAvailableEmail(decimal price, CancellationToken cancellationToken)
        {
            var isEmailExist = await _db.Products.Where(Q => Q.Price == price)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isEmailExist;
        }*/
    }
}
