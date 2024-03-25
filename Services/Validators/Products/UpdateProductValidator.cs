using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDataRequest>
    {
        private readonly DBContext _db;
        public UpdateProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductName).NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Maximum 50 characters.");

            RuleFor(Q => Q.ProductPrice)
                .NotEmpty().WithMessage("Ain't no way the price is empty");
                
        }

        private async Task<bool> AvailableId(Guid productId, CancellationToken token)
        {
            var isIdExist = await _db.Products.Where(Q => Q.ProductID == productId).AsNoTracking().AnyAsync();
            return isIdExist;
        }
    }
}
