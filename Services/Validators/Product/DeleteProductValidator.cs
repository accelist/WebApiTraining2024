
using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Product
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        private readonly DBContext _db;
        public DeleteProductValidator(DBContext db)
        {
            _db = db;
            RuleFor(Q => Q.ProductId).NotEmpty().MustAsync(ProductIDExists).WithMessage("Product ID was not found.");
        }

        public async Task<bool> ProductIDExists(Guid id, CancellationToken cancellationToken)
        {
            bool IsExist = await _db.Products.Where(Q => Q.ProductID == id).AsNoTracking().AnyAsync(cancellationToken);
            return IsExist;
        }
    }
}
