
using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Product
{
    public class ProductDetailValidator : AbstractValidator<ProductDetailRequest>
    {
        private readonly DBContext _db;
        public ProductDetailValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.ProductId).NotEmpty().MustAsync(ProductIDExists).WithMessage("This product ID was not found.");
        }

        public async Task<bool> ProductIDExists(Guid id, CancellationToken cancellationToken)
        {
            bool IsExist = await _db.Products.Where(Q => Q.ProductID == id).AsNoTracking().AnyAsync(cancellationToken);
            return IsExist;
        }
    }
}
