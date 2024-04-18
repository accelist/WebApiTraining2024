using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Product
{
    public class EditProductValidator : AbstractValidator<EditProductRequest>
    {
        private readonly DBContext _db;

        public EditProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductID).MustAsync(IsProductExist).WithMessage("Product not exist.");

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.Price).NotNull().WithMessage("Price cannot be empty.");
        }

        private async Task<bool> IsProductExist(Guid productID, CancellationToken cancellationToken)
        {
            var isProductExist = await _db.Products.Where(Q => Q.ProductID == productID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isProductExist;
        }
    }
}
