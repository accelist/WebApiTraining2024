using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Product
{
    public class GetProductDataListHandler : AbstractValidator<CreateProductRequest>
    {
        private readonly DBContext _db;

        public GetProductDataListHandler(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductName).NotEmpty().WithMessage("Name Cannot be Empty")
                .MaximumLength(50).WithMessage("Maximum 50 characters.")
                .MustAsync(IsNameAvailable).WithMessage("Product already exist.");

            RuleFor(Q => Q.Price).NotEmpty().WithMessage("Price Cannot be Empty.")
                .GreaterThanOrEqualTo(10000).WithMessage("Minimum price is 10000.");
        }

        public async Task<bool> IsNameAvailable(string name, CancellationToken cancellationToken)
        {
            var isName = await _db.Products.Where(Q => Q.Name == name)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isName;
        }
    }
}
