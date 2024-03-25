using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Product
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdRequest>
    {
        private readonly DBContext _db;

        public GetProductByIdValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductId).NotEmpty().WithMessage("ID cannot be empty.")
                .MustAsync(ExistingID).WithMessage("ID does not exist.");
        }

        private async Task<bool> ExistingID(Guid id, CancellationToken cancellationToken)
        {
            var existingID = await _db.Products
                .Where(Q => Q.ProductID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return existingID;
        }
    }
}
