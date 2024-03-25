using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Products
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdRequest>
    {
        private readonly DBContext _db;
        public GetProductByIdValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductId).NotEmpty().WithMessage("Id not found")
                .MustAsync(AvailableId).WithMessage("Id is not exist");
        }

        private async Task<bool> AvailableId(Guid? productId, CancellationToken token)
        {
            var isIdExist = await _db.Products.Where(Q => Q.ProductID == productId).AsNoTracking().AnyAsync();
            return isIdExist;
        }


    }
}
