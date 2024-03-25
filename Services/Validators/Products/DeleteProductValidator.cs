using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Services.RequestHandlers.ManageProduct;

namespace Services.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        private readonly DBContext _db;
        public DeleteProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductId).NotEmpty().WithMessage("Id not found")
                .MustAsync(AvailableId).WithMessage("Id is not exist");
        }

        private async Task<bool> AvailableId(Guid productId, CancellationToken token)
        {
            var isIdExist = await _db.Products.Where(Q => Q.ProductID == productId).AsNoTracking().AnyAsync();
            return isIdExist;
        }
    }
}
