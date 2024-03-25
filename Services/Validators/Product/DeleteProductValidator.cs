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
            RuleFor(Q => Q.Id).NotEmpty().WithMessage("ID cannot be empty.")
                .MustAsync(ExistingID).WithMessage("ID does not exist.");
        }

        public async Task<bool> ExistingID(Guid id, CancellationToken cancellationToken)
        {
            var existingID = await _db.Products
                .Where(Q => Q.ProductID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return existingID;
        }
    }
}
